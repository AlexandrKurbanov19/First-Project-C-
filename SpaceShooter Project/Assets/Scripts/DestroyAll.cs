using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
   //нужна приватная ссылка на бокс коллайдер 2д который на обьекте
   private BoxCollider2D _boundare_Collider;
   //приватная переменная для угла камеры
   private Vector2 _viewport_Size;

   private void Awake()
   {
       //настроим ссылку на бокс колайдер
       _boundare_Collider = GetComponent<BoxCollider2D>();
   }
   private void Start()
   {
       //вызываем метод для рассчета бокс кол
       ResizeCollider();
   }
   //напишем код для метода
   void ResizeCollider()
   {
       //для этого мы должны получить значение верхнего правого угла камеры и умножить на 2
       _viewport_Size = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
       //умножим ширину и высоту на 1.5 
       _viewport_Size.x *=1.5f;
       _viewport_Size.y *=1.5f;
       //изменим размер используя расчеты
       _boundare_Collider.size = _viewport_Size;
   }

   public void OnTriggerExit2D(Collider2D coll)
   {
       //мы будем уничтожать любые обьекты чьи теги в данном коде
       //описание планет
       switch (coll.tag)
       {
           case "Planet":
           Destroy(coll.gameObject);
           break;
       }
   }
}
