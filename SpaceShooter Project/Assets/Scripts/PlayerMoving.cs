using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ограничение перемещение игрока
[System.Serializable]
public class Borders 
{
    //добавим 4 поля в котором будут храниться отступы
    public float minX_Offset = 1.1f;
    //отступ от правой границы
    public float maxX_Offset = 1.1f;
    //отступ нижний
    public float minY_Offset = 1.1f;
    //верхний
    public float maxY_Offset = 1.1f;
    //добавим еще полей скрытых для рассчета
    //4 публичных поля скрытых от инспектора, они ограничывают передвижение игрока
    [HideInInspector]
    public float minX, maxX, minY, maxY;
}
public class PlayerMoving: MonoBehaviour 
{
    // ссылка на самого себя через нее можем меня скорость игрока и сцен
    public static PlayerMoving instance;
    //ссылка на границы
    public Borders borders;
    //переменная для хранения скорости игрока 
    public int speed_Player = 5;
    //приватная ссылка на камеру для взаимодействия с экраном
    private Camera _camera;
    //переменная для хранения 2д координат
    private Vector2 _mouse_Position;

     private void Awake()   //тут будут настраиваться наши ссылки 
     {
         //настраиваем ссылку на саму себя
         if (instance == null)
         {
             instance = this; //
         }
        else
        { 
            Destroy(gameObject);
        }
        _camera = Camera.main;
     }

     private void Start()
     {
         //мы будем вызывать метод рассчета границ
         ResizeBorders();

     }

    private void Update()
    {
        //делаем условие в котором проверям была ли нажата левая клавиша мыши по экрану 
        if (Input.GetMouseButton(0))
        {
            //если нажали на экран то в переменную записываем место нажатия
            _mouse_Position = _camera.ScreenToWorldPoint(Input.mousePosition);
            //после перемещаем данные игрока или обьект на котором висит данный скрипт 
            transform.position = Vector2.MoveTowards(transform.position, _mouse_Position, speed_Player * Time.deltaTime);
            
        }
        //если игрок пытаеться выйти из границ не пускаем его
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                                         Mathf.Clamp(transform.position.y, borders.minY, borders.maxY));
    }

    //код для метода рассчета границ
    //будет работать с любыми экранами и создавать границы
    private void ResizeBorders()
    {
        //левая граница
        borders.minX = _camera.ViewportToWorldPoint(Vector2.zero).x + borders.minX_Offset;
        //низ
        borders.minY = _camera.ViewportToWorldPoint(Vector2.zero).y + borders.minY_Offset;
        //right
        borders.maxX = _camera.ViewportToWorldPoint(Vector2.right).x - borders.maxX_Offset;
        //top
        borders.maxY = _camera.ViewportToWorldPoint(Vector2.up).y -  borders.maxY_Offset;
    }
}
