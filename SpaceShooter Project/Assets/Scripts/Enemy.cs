using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   //создаем переменную хранения здоровья врага
   public int enemy_Health;


   [Space]
    //переменная для хранения пуль врага
    public GameObject obj_Bullet;
    //интервал выстрелов по времени
    public float shot_Time_Min, shot_Time_Max;
    //что бы не все враги разом производили выстрел
    public int shot_Chance;

    private void Start()
    {
        //будем вызывать опен вайер который будем вызываться в случайный промежуток времени нашего интервала
        //если хотим что бы стреляло постоянно это строку в update
        Invoke("OpenFire", Random.Range(shot_Time_Min, shot_Time_Max));
    }

    //метод опенвайер
    private void OpenFire()
    {
        //условия где проверяем шанс выстрела
        if (Random.value < (float)shot_Chance / 100)
        {
            //создаем пули с позиции врага
            Instantiate(obj_Bullet, transform.position, Quaternion.identity);
        }

    }

   //метод отвечающий за получение урона врагу
   public void GetDamage(int damage)
   {
       //уменьшаем очки на колличество полученного урона
       enemy_Health -= damage;
       //условие если у врага нет очков жизни вызываем метод разрушения врага
       if (enemy_Health <= 0)
       {
           //вызываем метод разрушения
           Destruction();
       }

   }
   //опишим метод разрушения врага
   private void Destruction()
   {
       //при вызове обьект уничтожаеться
       Destroy(gameObject);
   }
   //опишим действие столкновения врага и игроком
   private void OnTriggerEnter2D(Collider2D coll)
   {
       if (coll.tag == "Player")
       {
           GetDamage(1);
           Player.instance.GetDamage(1);
       }
   }
}
