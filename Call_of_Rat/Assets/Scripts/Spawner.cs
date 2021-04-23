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
    /// ����� �������� �� ������
    /// </summary>
    /// <param name="go">������ ��� ������</param>
    /// <param name="points">����� ������</param>
    /// <param name="go_count">���������� ��������</param>
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
    /// ��������� ����� ������
    /// </summary>
    /// <param name="go">�������� ����� ������</param>
    /// <returns></returns>
    private List<Transform> GetPoints(GameObject go)
    {
        var list = new List<Transform>();
        for (int i = 0; i < go.transform.childCount; i++)
            list.Add(go.transform.GetChild(i).transform);
        return list;
    }
}
