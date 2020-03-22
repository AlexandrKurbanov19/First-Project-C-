using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
  //нужен массив в котором будут точки пути для полета врага
  public Transform[] path_Points;
  //переменная для хранения скорости врага
  public float speed_Enemy;
  //логическая переменная пути врага
  public bool is_return;

  //масив для хранения векторов наших точек пути тестовый аврик
  public Vector3[] _new_Position;


  //переменная для хранения порядкового номера точек пути враг будет знатт куда лететь
  private int cur_Pos;

    private void Start()
    {
        _new_Position = NewPositionByPath(path_Points);
        //в старте отправим врага в начальную точку пути
        transform.position = _new_Position[0];

    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        //Права на данный курс принадлежат Дорофеевой Карине Олеговне, данный курс создавался для Udemy сайта
    private void Update()
    
    {
        //перемещаем врага в точку пити с заданной скоростью
         transform.position = Vector3.MoveTowards(transform.position, _new_Position[cur_Pos], speed_Enemy * Time.deltaTime);
        //условие если текущий враг добрался до точки пути то мы добавляем в переменную для хранения пути 1, т.к. новая цель движения
       if (Vector3.Distance(transform.position, _new_Position[cur_Pos]) < 0.2f)
        {
           //следующая точка пути
           cur_Pos++;
           // делаем условие если текущий враг добрался до конца пути мы заставляем его начать сначала
           if (is_return && Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.3f)
                cur_Pos = 0;
        }
            //если текущий враг добрался до конечной цели и текущая переменная ложь то мы уничтожаем врага
            if (Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.2f && !is_return)
        {
            Destroy(gameObject);
        }
    }

    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathPositions = new Vector3[pathPos.Length];
        for (int i = 0; i < path_Points.Length; i++)
        {
            pathPositions[i] = pathPos[i].position;
        }
        return pathPositions;
    }
   
}
