using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoving : MonoBehaviour
{
    //переменная для хранения скорости 
 public float speed;
 
 private void Update()
 {
     //перемещение обьекта по вертикальной плоскости
     transform.Translate(Vector3.up * speed * Time.deltaTime);

 }
}
