using UnityEngine;

public class player : MonoBehaviour
{
    //public GameObject bullet;
    //public Transform bulletStartPosition;

    //public GameObject enemy;
    //private readonly Rigidbody _rb;

    [SerializeField] private GameObject trigger_nand;
    [SerializeField] public Transform p_camera;

    //������������� ��������
    private void Awake()
    {

    }

    private void Start()
    {
        //Enemy e = enemy.GetComponent<Enemy>();
        //if (e != null)
        //{
        //    Debug.Log(e.hp_);
        //}
    }

    private void Update()
    {

        takeHand();


        //if (Input.GetMouseButton(0))
        //{
        //    Fare();
        //}
        //bullet.transform.Translate(Time.deltaTime, 0, 0);
    }

    //������
    private void FixedUpdate()
    {

    }

    /// <summary>
    /// �������������� � ���������
    /// </summary>
    private void takeHand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            trigger_nand.SetActive(true);
            Debug.Log("enter_e");

            // ������� ������� � ������� ������
            trigger_nand.transform.rotation = p_camera.rotation;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            trigger_nand.SetActive(false);
        }

    }

    private void Fare()
    {
        //Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);
    }
}
