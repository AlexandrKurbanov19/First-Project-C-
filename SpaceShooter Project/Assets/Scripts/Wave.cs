using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
   //переменная для хранения врага 
   public GameObject obj_Enemy;
   //колличество врага в волне
   public int count_in_Wave;
   //скорость волны
   public float speed_Enemy;
   //задержка между генерацией врагов в волне
   public float time_Spawn;
   //массив для хранения точек по которым двигаеться волна
   public Transform[] path_Points;
   //логическая переменная, последний пунк пути в которой враг либо уничтожен лиюо начинает заново
   public bool is_return;
   
   //Тест Волны
    [Header("Test wave!")]
    public bool is_Test_Wave;

    private FollowThePath follow_Component;

    private void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }

    IEnumerator CreateEnemyWave()
    {
        //цикл который зависит от колличества врагов в волне
        for (int i = 0; i < count_in_Wave; i++)
        {
            GameObject new_enemy = Instantiate(obj_Enemy, obj_Enemy.transform.position, Quaternion.identity);

            follow_Component = new_enemy.GetComponent<FollowThePath>();
            //через ссылку пеередадим точки пути по которым должен двигаться враг
            follow_Component.path_Points = path_Points;
            //скорость волны
            follow_Component.speed_Enemy = speed_Enemy;
            //через ссылку передаем значение логической переменной
            follow_Component.is_return = is_return;

            new_enemy.SetActive(true);
            // делаем задерку 
            yield return new WaitForSeconds(time_Spawn);
        }
        if(is_Test_Wave)
        {
            //ждем 5 секунд запускаем волну
            yield return new WaitForSeconds(5f);
            StartCoroutine(CreateEnemyWave());
        }

        if (!is_return)
        {
            Destroy(gameObject);
        }

    }



}
