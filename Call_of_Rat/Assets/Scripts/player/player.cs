using UnityEngine;

public class Player : MonoBehaviour
{
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
    /// ���-�� ������ ������ (5 ��� ��������)
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
    public float are_fire = 7f;
    /// <summary>
    /// �������� �������� ��������
    /// </summary>
    public float speed_fire_time = 0.2f;

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
        //if (flag_take_censer) FireAnimation();
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
            flag_fire = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _holy_fire.SetActive(false);
            flag_fire = false;
        }
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    private void FireAnimation()
    {
        if (flag_fire)
        {
            _holy_fire.transform.localScale = new Vector3(Mathf.PingPong(Time.deltaTime, 20f), 0, Mathf.PingPong(Time.deltaTime, 20f));
        }
    }
}
