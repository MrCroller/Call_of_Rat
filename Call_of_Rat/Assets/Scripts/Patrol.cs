using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    /// <summary>
    /// ����� ��������
    /// </summary>
    public float startWaitTime = 3f;

    /// <summary>
    /// �������� ���������� �� ������
    /// </summary>
    private Coroutine _coroutine_target_point;
    /// <summary>
    /// �������� ���������� �� �������
    /// </summary>
    private readonly Coroutine _coroutine_target_player;

    /// <summary>
    /// ������
    /// </summary>
    private CapsuleCollider _vision;

    private Animator _animator;

    /// <summary>
    /// ������� ������
    /// </summary>
    public Transform player;
    /// <summary>
    /// ������ ����� ��� ��������
    /// </summary>
    [SerializeField] private Transform[] _walk_points;
    private int _randomSpot;

    private NavMeshAgent _navMesh;
    /// <summary>
    /// ����������� ��������� �� ����� ��������������
    /// </summary>
    private readonly float _minDistance_point = 1.3f;
    /// <summary>
    /// ����������� ��������� ��� ������ �� ������
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
            Debug.Log("�������!");
            VisiblePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���� �� ��?");
            StartCoroutine(LoseSight());
        }
    }

    /// <summary>
    /// ��������� �������� ������
    /// </summary>
    public void VisionSet(Player_controller.SpeedState speed_st)
    {
        // ����� �� ��� ���������� �� ���� ���������� ����� ������� �����
        if (speed_st == Player_controller.SpeedState.Normal)
        {
            // ���������� ������
            _vision.radius = 1.27f;
            _vision.height = 3.7f;
        }
        else if (speed_st == Player_controller.SpeedState.Sprint)
        {
            // ����������� ������
            _vision.radius = 2f;
            _vision.height = 6.23f;
        }
        else if (speed_st == Player_controller.SpeedState.Stealth)
        {
            // ���������� ������
            _vision.radius = 1f;
            _vision.height = 2.76f;
        }
    }

    /// <summary>
    /// ����� �������������� �����
    /// </summary>
    private IEnumerator PointWalk()
    {
        _navMesh.speed = 1.8f; // �������� ��������������
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
    /// ����� ������������� ������
    /// </summary>
    private void VisiblePlayer()
    {
        _navMesh.speed = 3f; // �������� ������������� ������;
        StopAllCoroutines();
        Walk(player);
        if (Vector3.Distance(transform.position, player.position) < _minDistance_player)
        {
            Attack();
        }
    }

    /// <summary>
    /// �������� ��� ������ ������ �� ����
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoseSight()
    {
        for (float i = 0; i < 12f; i += Time.deltaTime) // ������ ��� ������
        {
            yield return null;
            Walk(player);
        }
        // ����� ����� ������ ������
        yield return new WaitForSeconds(10f);
        _animator.SetBool("lose", true);
        yield return new WaitForSeconds(3f);
        _animator.SetBool("lose", false);
        StartCoroutine(PointWalk());
    }

    /// <summary>
    /// ����� �������� � �������
    /// </summary>
    /// <param name="target"></param>
    private void Walk(Transform walk_point)
    {
        _navMesh.SetDestination(walk_point.position);
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    private void Attack()
    {
        transform.LookAt(player);
        StopAllCoroutines();

        _animator.SetBool("Jump", true);

    }
}
