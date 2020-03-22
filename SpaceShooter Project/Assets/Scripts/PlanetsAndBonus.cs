using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonus : MonoBehaviour
{
    //массив для генерации планет
    public GameObject[] obj_Planets;
     //задержка между генерацие планет
    public float time_Planet_Spawn;
   //переменная для хранения скорости появления планет
    public float speed_Planets;
    //Список планет
     //список который запрещает дублирование планет подряд.
    List<GameObject> planetsList = new List<GameObject>();

    private void Start()
    {
        //будем запускать прогу которая генерирует планеты
        StartCoroutine(PlanetsCreation());
    }

    IEnumerator PlanetsCreation()
    {
         //добавим планеты в список используя цикл
        for (int i = 0; i < obj_Planets.Length; i++)
        {
            planetsList.Add(obj_Planets[i]);
        }
        //после заполнения списка ждем 7 секунд и запускаем выполнение кода
        yield return new WaitForSeconds(7);
         //создаем планеты в бесконечном цикле
        while (true)
        {
             //выбераем случаюную планету
            int randomIndex = Random.Range(0, planetsList.Count);
            // Create an instance of the planet, taking into account the limits of the player’s movement width
            // The planet will be created above the camera's visibility
            // The planets will move at an angle in the range of -25 to 25. 
            GameObject newPlanet = Instantiate(planetsList[randomIndex],
                new Vector2(Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX),
                PlayerMoving.instance.borders.maxY * 1.7f),
                Quaternion.Euler(0, 0, Random.Range(-25, 25)));

            //после создания планеты удаляем ее из списка что бы не дублировать ее
            planetsList.RemoveAt(randomIndex);
            //если список стал пустым наполнить его заново
            if (planetsList.Count == 0)
            {
                for (int i = 0; i < obj_Planets.Length; i++)
                {
                    planetsList.Add(obj_Planets[i]);
                }
            }
            //задаем скорость 
            newPlanet.GetComponent<ObjMoving>().speed = speed_Planets;
            // Every time_Planet_Spawn seconds
            yield return new WaitForSeconds(time_Planet_Spawn);
        }
    }
}