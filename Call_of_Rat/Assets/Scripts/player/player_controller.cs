using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    private Vector3 _direction;

    private float _xRot;
    private float _yRot;
    public Camera player;
    public float sensivity = 200f;

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
    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) _speed += 4;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _speed -= 4;
    }
    private void MouseMove()
    {
        _xRot += Input.GetAxis("Mouse X") * sensivity;
        _yRot += Input.GetAxis("Mouse Y") * sensivity;

        // Ограничение максимального поворота
        _yRot = Mathf.Clamp(_yRot, -85, 60);

        // Сглаживание поворота мышкой
        _xRotCurrent = Mathf.SmoothDamp(_xRot, _xRotCurrent, ref _currentVelosityX, _smoothTime);
        _yRotCurrent = Mathf.SmoothDamp(_yRot, _yRotCurrent, ref _currentVelosityY, _smoothTime);

        player.transform.rotation = Quaternion.Euler(-_yRotCurrent, _xRotCurrent, 0f);
        playerGO.transform.rotation = Quaternion.Euler(0f, _xRot, 0f);
    }
}
