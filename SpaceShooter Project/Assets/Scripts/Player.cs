using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  //ссылка на самого себя через нее можно наносить урон или взаимодействовать с магазином
  public static Player instance = null;

  //переменная для хранения очков жизни игрока
  public int player_Health = 1;

  private void Awake()
  {
      //настраиваем ссылку на самого себя
      if (instance == null)
      {
          instance = this;
      }
      else
      {
          Destroy(gameObject);
      }
  }

  //метод получения урона игроком
  public void GetDamage(int damage)
  {
      //уменьшим очки жизни игрока на кол во полученного урона
      player_Health -= damage;
      //условие если у игрока нет жизни разрушаем егоэ
      if (player_Health <= 0)
      {
          //вызываем метод разрушения
          Destruction();
      }

  }
  //метод разрушение игрока
  void Destruction()
  {
      //если метод вызван игроку фаталити
      Destroy(gameObject);
  }
}
