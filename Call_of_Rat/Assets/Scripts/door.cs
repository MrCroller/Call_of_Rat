using UnityEngine;

public class door : MonoBehaviour
{
    // Тригер открытия двери
    [SerializeField] public GameObject key;

    [SerializeField] private GameObject _lock;
    [SerializeField] private Transform _sash;
    [SerializeField] private Transform _door;
    private Vector3 openPosition;
    public bool button_flag = false;

    private void Start()
    {
        // Получение позиции открытой щеколды
        openPosition = _sash.position + new Vector3(0, 0, 0.35f);
    }

    private void FixedUpdate()
    {
        if (button_flag) Open();
    }

    /// <summary>
    /// Метод открытия двери
    /// </summary>
    public void Open()
    {
        // Снятие замка
        _lock.SetActive(false);

        // Движение щеколды
        //_sash.position = Vector3.MoveTowards(_sash.position, openPosition, 0.3f * Time.deltaTime);

        // Поворот двери
        //if (_sash.position == openPosition)
        //{
        _door.rotation = Quaternion.Slerp(_door.rotation, Quaternion.Euler(0, -80, 0), Time.deltaTime);
        //}

        if (_door.rotation == Quaternion.Euler(0, -80, 0))
        {
            button_flag = false;
            Debug.Log("open");
        }
    }
}
