using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletStartPosition;

    [SerializeField] private GameObject _trigger_nand;
    [SerializeField] public Transform p_camera;
    [SerializeField] private Transform _Right_hand;

    /// <summary>
    ///  ������ ������
    /// </summary>
    [SerializeField] private GameObject _censer;
    /// <summary>
    /// ��������� ����� (�������)
    /// </summary>
    [SerializeField] private GameObject _holy_fire;
    /// <summary>
    /// ��������� ������� ������� ��������
    /// </summary>
    private Transform _start_fire_position;

    /// <summary>
    /// ���-�� ������ �� ��������� ������� (5 ��� ��������)
    /// </summary>
    public int key_count = 0;

    /// <summary>
    /// ���� ������ ������
    /// </summary>
    public bool flag_take_censer = false;
    /// <summary>
    /// ���� ��������
    /// </summary>
    private bool flag_fire = false;
    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    private bool flag_active_censer = false;

    /// <summary>
    /// ������� ���������
    /// </summary>
    public float are_fire = 5f;
    /// <summary>
    /// �������� �������� ��������
    /// </summary>
    public float speed_fire_time = 4f;

    private void Start()
    {
        _start_fire_position = _holy_fire.transform;
    }

    private void Update()
    {
        TakeHand();
        if (flag_take_censer)
        {
            Censer_Active();
            Fare();
        }
    }

    private void FixedUpdate()
    {
        if (flag_take_censer) FireAnimation();
    }

    /// <summary>
    /// �������������� � ���������
    /// </summary>
    private void TakeHand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _trigger_nand.SetActive(true);
            Debug.Log("enter_e");

            // ������� ������� � ������� ������
            _trigger_nand.transform.rotation = p_camera.rotation;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _trigger_nand.SetActive(false);
        }

    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    private void Censer_Active()
    {
        if (!flag_active_censer)
        {
            _Right_hand.Rotate(-120f, 0, 0, Space.Self);
            _censer.SetActive(true);
            flag_active_censer = true;
        }
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    private void Fare()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("holy_fire!");
            _holy_fire.SetActive(true);
            _holy_fire.transform.localScale = _start_fire_position.localScale;
            flag_fire = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _holy_fire.SetActive(false);
            _holy_fire.transform.localScale = _start_fire_position.localScale;
            flag_fire = false;
        }
        
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    private void FireAnimation()
    {
        if (flag_fire && (_holy_fire.transform.localScale == new Vector3(are_fire, 1f, are_fire)))
        {
            _holy_fire.transform.localScale += new Vector3(Time.deltaTime * speed_fire_time, 0, Time.deltaTime * speed_fire_time);
        }
        else if (!flag_fire && (_holy_fire.transform.localScale != _start_fire_position.localScale))
        {
            _holy_fire.transform.localScale -= new Vector3(Time.deltaTime * speed_fire_time, 0, Time.deltaTime * speed_fire_time);
        }

    }
}
