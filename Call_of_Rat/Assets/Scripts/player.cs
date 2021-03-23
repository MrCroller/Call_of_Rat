using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletStartPosition;

    public GameObject enemy;
    private Rigidbody _rb;

    private float _speed = 2;
    private Vector3 _direction;

    //Инициализация объектов
    private void Awake()
    {

    }

    void Start()
    {
        var e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            Debug.Log(e.hp_);
        }
    }

    private void Update()
    {

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        //if (Input.GetMouseButton(0))
        //{
        //    Fare();
        //}
        //bullet.transform.Translate(Time.deltaTime, 0, 0);
    }

    //Физика
    private void FixedUpdate()
    {
        var speed = _direction * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    private void LateUpdate()
    {

    }

    private void Fare()
    {
        Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);  
    }
}
