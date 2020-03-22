using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Repeating : MonoBehaviour
{
    //переменная для хранения высоты спрайтов пикселей
     public float vertical_Size;
      //приватная переменная для хранения данных о повышении спрайта
    private Vector2 _offSet_Up;

    private void Update()
    {
        //условия для проверки спрайта 
        if (transform.position.y < -vertical_Size)
        {
            //вызываем метод
            RepeatBackground();
        }
    }
    //метод репита бэка бесконечный фон
    void RepeatBackground()
    {
        //расчет смешения переменной
        _offSet_Up = new Vector2(0, vertical_Size * 2f);
        //новая позиция 
        transform.position = (Vector2)transform.position + _offSet_Up;
    }
}
