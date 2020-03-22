using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //переменная через которую мы можем регулировать силу наносимого урона отпули
    public int damage;
    //добавим логическую переменную через нее мы решаем чья пуля игрока или врага универсальный скрипт
    public bool is_Enemy_Bullet;

    //опишем метод разрушения пулей
    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //условие если пуля врага и сталкиваеться с игроком то мы вызываем метод повреждения игрока и наносим ему урон
        if (is_Enemy_Bullet && coll.tag == "Player")
        {
            //вызываем метод наноса повреждений игроку
            Player.instance.GetDamage(damage);  
            //после столкновения мы вызываем метод разрушения пулей
            Destruction();
        }
        //если пуля игрока и наносит урон врагу то мы у врага через компонет отнимаем здоровье
        else if (!is_Enemy_Bullet && coll.tag == "Enemy")
        {
            //
            coll.GetComponent<Enemy>().GetDamage(damage);
            //метод разрушения пулей
            Destruction();
        }
    }
}
