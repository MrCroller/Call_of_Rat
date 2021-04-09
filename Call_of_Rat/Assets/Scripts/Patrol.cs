using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    /// <summary>
    /// Время ожидания
    /// </summary>
    public float startWaitTime = 3f;

    /// <summary>
    /// Корутина следования по точкам
    /// </summary>
    private Coroutine _coroutine_target_point;
    /// <summary>
    /// Корутина следования за игроком
    /// </summary>
    private readonly Coroutine _coroutine_target_player;

    /// <summary>
    /// Зрение
    /// </summary>
    private CapsuleCollider _vision;

    private Animator _animator;

    /// <summary>
    /// Позиция игрока
    /// </summary>
    public Transform player;
    /// <summary>
    /// Массив точек для движения
    /// </summary>
    [SerializeField] private Transform[] _walk_points;
    private int _randomSpot;

    private NavMeshAgent _navMesh;
    /// <summary>
    /// Минимальная дистанция до точки патрулирования
    /// </summary>
    private readonly float _minDistance_point = 1.3f;
    /// <summary>
    /// Минимальная дистанция для прыжка на игрока
    /// </summary>
    private readonly float _minDistance_player = 3.7f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMesh = GetComponent<NavMeshAgent>();
        _vision = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _randomSpot = Random.Range(0, _walk_points.Length);

        _coroutine_target_point = StartCoroutine(PointWalk());
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Папався!");
            VisiblePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Куда же ты?");
            StartCoroutine(LoseSight());
        }
    }

    /// <summary>
    /// Установка величины зрения
    /// </summary>
    public void VisionSet(Player_controller.SpeedState speed_st)
    {
        // знать бы как обращаться ко всем владельцам этого скрипта сразу
        if (speed_st == Player_controller.SpeedState.Normal)
        {
            // нормальное зрение
            _vision.radius = 1.27f;
            _vision.height = 3.7f;
        }
        else if (speed_st == Player_controller.SpeedState.Sprint)
        {
            // увеличенное зрение
            _vision.radius = 2f;
            _vision.height = 6.23f;
        }
        else if (speed_st == Player_controller.SpeedState.Stealth)
        {
            // уменьшеное зрение
            _vision.radius = 1f;
            _vision.height = 2.76f;
        }
    }

    /// <summary>
    /// Метод потрулирования точек
    /// </summary>
    private IEnumerator PointWalk()
    {
        _navMesh.speed = 1.8f; // Скорость патрулирования
        while (true)
        {
            Walk(_walk_points[_randomSpot]);

            if (Vector3.Distance(transform.position, _walk_points[_randomSpot].position) < _minDistance_point)
            {
                yield return new WaitForSeconds(startWaitTime);
                _randomSpot = Random.Range(0, _walk_points.Length);
            }
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// Метод преследования игрока
    /// </summary>
    private void VisiblePlayer()
    {
        _navMesh.speed = 3f; // Скорость преследования игрока;
        StopAllCoroutines();
        Walk(player);
        if (Vector3.Distance(transform.position, player.position) < _minDistance_player)
        {
            Attack();
        }
    }

    /// <summary>
    /// Действия при потере игрока из виду
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoseSight()
    {
        for (float i = 0; i < 12f; i += Time.deltaTime) // Таймер для отсчет
        {
            yield return null;
            Walk(player);
        }
        // Пауза после потери игрока
        yield return new WaitForSeconds(10f);
        _animator.SetBool("lose", true);
        yield return new WaitForSeconds(3f);
        _animator.SetBool("lose", false);
        StartCoroutine(PointWalk());
    }

    /// <summary>
    /// Метод движение к объекту
    /// </summary>
    /// <param name="target"></param>
    private void Walk(Transform walk_point)
    {
        _navMesh.SetDestination(walk_point.position);
    }

    /// <summary>
    /// Атака игрока
    /// </summary>
    private void Attack()
    {
        transform.LookAt(player);
        StopAllCoroutines();

        _animator.SetBool("Jump", true);

    }
}
