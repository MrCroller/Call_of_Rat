using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private float _waitTime;
    /// <summary>
    /// Время ожидания
    /// </summary>
    public float startWaitTime;

    /// <summary>
    /// Массив точек для движения
    /// </summary>
    [SerializeField] private Transform[] _walk_points;
    private int _randomSpot;

    private void Start()
    {
        _waitTime = startWaitTime;
        _randomSpot = Random.Range(0, _walk_points.Length);
    }

    private void Update()
    {
        TargetWalk();
    }

    /// <summary>
    /// Метод определения цели
    /// </summary>
    private void TargetWalk()
    {
        Walk(_walk_points[_randomSpot]);

        if (Vector3.Distance(transform.position, _walk_points[_randomSpot].position) < 1.3f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _walk_points.Length);
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Метод движение к объекту
    /// </summary>
    /// <param name="target"></param>
    private void Walk(Transform walk_point)
    {
        GetComponent<NavMeshAgent>().SetDestination(walk_point.position);
    }

    public IEnumerator WaitForRandom()
    {
        yield return new WaitForSeconds(Random.Range(2,5));
    }
}
