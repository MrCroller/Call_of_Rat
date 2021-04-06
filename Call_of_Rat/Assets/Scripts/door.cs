using UnityEngine;

public class Door : MonoBehaviour
{
    // Тригер открытия двери
    [SerializeField] public GameObject key;

    /// <summary>
    /// Замок на двери
    /// </summary>
    [SerializeField] private GameObject _lock;
    /// <summary>
    /// Щеколда
    /// </summary>
    [SerializeField] private Transform _sash;
    /// <summary>
    /// Дверь (поворот)
    /// </summary>
    [SerializeField] private Transform _door;
    private Vector3 _openPosition_sash;
    private Quaternion _openPosition_door;

    /// <summary>
    /// Флаг для открытия двери
    /// </summary>
    public bool flag_door_open = false;

    private void Start()
    {
        // Получение позиции открытой щеколды
        _openPosition_sash = _sash.position + new Vector3(0, 0, 0.35f);

        // Получение позиции открытой двери
        _openPosition_door = _door.rotation * Quaternion.Euler(0f, -80f, 0f);
    }

    private void FixedUpdate()
    {
        if (flag_door_open)
        {
            Open();
        }
    }

    /// <summary>
    /// Метод открытия двери
    /// </summary>
    private void Open()
    {
        // Снятие замка
        _lock.SetActive(false);

        // Движение щеколды
        //_sash.position = Vector3.MoveTowards(_sash.position, openPosition, 0.3f * Time.deltaTime);

        // Поворот двери
        //if (_sash.position == openPosition)
        //{
        _door.rotation = Quaternion.SlerpUnclamped(_door.rotation, _openPosition_door, 0.6f * Time.deltaTime);
        //}

        if (_door.rotation == _openPosition_door)
        {
            flag_door_open = false;
            Debug.Log("open");
        }
    }

    public void Open_door()
    {
        flag_door_open = true;
    }
}
