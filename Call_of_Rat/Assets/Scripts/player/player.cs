using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletStartPosition;

    //public GameObject enemy;
    //private readonly Rigidbody _rb;

    [SerializeField] private GameObject _trigger_nand;

    [SerializeField] public Transform p_camera;

    [SerializeField] private Transform _Right_hand;
    [SerializeField] private GameObject _censer;

    public bool flag_take_censer = false;
    private bool flag_fire = false;

    private void Update()
    {
        takeHand();
        if (flag_take_censer) Censer_Active();
        if (flag_fire && Input.GetMouseButtonDown(0)) Fare();
    }

    //Физика
    private void FixedUpdate()
    {

    }

    /// <summary>
    /// Взаимодействие с объектами
    /// </summary>
    private void takeHand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _trigger_nand.SetActive(true);
            Debug.Log("enter_e");

            // Поворот тригера в сторону камеры
            _trigger_nand.transform.rotation = p_camera.rotation;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _trigger_nand.SetActive(false);
        }

    }

    /// <summary>
    /// Метод активации оружия
    /// </summary>
    private void Censer_Active()
    {
        _Right_hand.Rotate(-120f, 0, 0, Space.Self);
        _censer.SetActive(true);
        flag_take_censer = false;
        flag_fire = true;
    }

    private void Fare()
    {
        Debug.Log("holy_fire!");
        //Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);
    }
}
