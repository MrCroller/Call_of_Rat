using UnityEngine;

public class Player_controller : MonoBehaviour
{
    /// <summary>
    /// Статусы движения персонажа
    /// </summary>
    private enum SpeedState
    {
        Sprint,
        Normal,
        Stealth
    }

    /// <summary>
    /// Статус режима движения персонажа
    /// </summary>
    private SpeedState setState;

    [SerializeField] private float _speed = 3f;
    private Vector3 _direction;

    private float _xRot;
    private float _yRot;
    public Camera p_camera;
    /// <summary>
    /// Чувствительность мыши
    /// </summary>
    public float sensivity = 200f;
    /// <summary>
    /// Ускорение бега
    /// </summary>
    public float sprint_value = 3f;
    /// <summary>
    /// Замедление скрытности
    /// </summary>
    public float stealth_value = 1.5f;

    private float _xRotCurrent;
    private float _yRotCurrent;
    private readonly float _smoothTime = 0.1f;
    private float _currentVelosityX;
    private float _currentVelosityY;

    public GameObject playerGO;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        MouseMove();

        Sprint();
    }

    private void FixedUpdate()
    {
        Vector3 speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Ускорение персонажа
    /// </summary>
    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed += sprint_value;
            setState = SpeedState.Sprint;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed -= sprint_value;
            setState = SpeedState.Sprint;
        }
    }

    /// <summary>
    /// Режим скрытности
    /// </summary>
    private void Stealth()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _speed -= stealth_value;
            setState = SpeedState.Stealth;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _speed += stealth_value;
            setState = SpeedState.Stealth;
        }
    }

    /// <summary>
    /// Управление зрением персонажа мышкой
    /// </summary>
    private void MouseMove()
    {
        _xRot += Input.GetAxis("Mouse X") * sensivity;
        _yRot += Input.GetAxis("Mouse Y") * sensivity;

        // Ограничение максимального поворота
        _yRot = Mathf.Clamp(_yRot, -75, 60);

        // Сглаживание поворота мышкой
        _xRotCurrent = Mathf.SmoothDamp(_xRot, _xRotCurrent, ref _currentVelosityX, _smoothTime);
        _yRotCurrent = Mathf.SmoothDamp(_yRot, _yRotCurrent, ref _currentVelosityY, _smoothTime);

        p_camera.transform.rotation = Quaternion.Euler(-_yRotCurrent, _xRotCurrent, 0f);
        playerGO.transform.rotation = Quaternion.Euler(0f, _xRot, 0f);
    }
}
