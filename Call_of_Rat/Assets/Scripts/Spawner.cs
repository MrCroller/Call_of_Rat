using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPointsParent;
    public GameObject object_spawn;
    public int object_count;

    private void Start()
    {
        SpawnPoint(object_spawn, GetPoints(spawnPointsParent), object_count);
    }

    /// <summary>
    /// Спавн объектов по точкам
    /// </summary>
    /// <param name="go">Объект для спауна</param>
    /// <param name="points">Точки спауна</param>
    /// <param name="go_count">Количество объектов</param>
    private void SpawnPoint(GameObject go, List<Transform> points, int go_count)
    {
        if (go_count == 0) go_count = points.Count;

        for(int i = 0; i < go_count; i++)
        {
            int rnd = Random.Range(0, points.Count);
            Instantiate(go, points[rnd]);
            points.RemoveAt(rnd);
        }
    }
     
    /// <summary>
    /// Получение точек спауна
    /// </summary>
    /// <param name="go">Родитель точек спауна</param>
    /// <returns></returns>
    private List<Transform> GetPoints(GameObject go)
    {
        var list = new List<Transform>();
        for (int i = 0; i < go.transform.childCount; i++)
            list.Add(go.transform.GetChild(i).transform);
        return list;
    }
}
