using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //дебаг
    //переменная для хранения пули игрока
    public GameObject obj_Bullet;
    //интервал выстрела пуль
    public float time_Bullet_Spawn = 0.3f;
    //переменная для создания таймера
    [HideInInspector]
    public float timer_Shot;

    private void Update()
    {
        //
        if(Time.time > timer_Shot)
        {
            timer_Shot = Time.time + time_Bullet_Spawn;
            //создание пули
            Instantiate(obj_Bullet, transform.position, Quaternion.identity);
        }
    }

}
