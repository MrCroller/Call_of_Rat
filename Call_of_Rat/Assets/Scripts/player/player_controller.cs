using UnityEngine;

public class player_controller : MonoBehaviour
{
    enum SpeedState
    {
        Sprint,
        Normal,
        Stealth
    }

    private SpeedState setState;

    [SerializeField] private float _speed = 3f;
    private Vector3 _direction;

    private float _xRot;
    private float _yRot;
    public Camera p_camera;
    public float sensivity = 200f;
    public float sprint_value = 3f;
    public float stealth_value = 1.5f;

    private float _xRotCurrent;
    private float _yRotCurrent;
    private readonly float _smoothTime = 0.1f;
    private float _currentVelosityX;
    private float _currentVelosityY;

    public GameObject playerGO;

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        MouseMove();
        Sprint();
    }

    private void FixedUpdate()
    {
        Vector3 speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    /// <summary>
    /// Ускорение персонажа
    /// </summary>
    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed += sprint_value;
            this.setState = SpeedState.Sprint;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed -= sprint_value;
            this.setState = SpeedState.Sprint;
        }
    }

    private void Stealth()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _speed -= stealth_value;
            this.setState = SpeedState.Stealth;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _speed += stealth_value;
            this.setState = SpeedState.Stealth;
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
