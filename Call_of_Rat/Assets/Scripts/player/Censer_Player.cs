using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Censer_Player : MonoBehaviour
{
    /// <summary>
    /// ������ ����
    /// </summary>
    [SerializeField] private Transform _Right_hand;
    /// <summary>
    ///  ������ ������
    /// </summary>
    [SerializeField] private GameObject _censer;
    /// <summary>
    /// ����
    /// </summary>
    [SerializeField] private GameObject _chains;
    /// <summary>
    /// ������� ����������� ������ (��������)
    /// </summary>
    [SerializeField] private GameObject _particle;
    /// <summary>
    /// ������� ����������� ������ (����)
    /// </summary>
    [SerializeField] private GameObject _pointlight;
    /// <summary>
    /// ��������� ����� (�������)
    /// </summary>
    [SerializeField] private GameObject _holy_fire;
    /// <summary>
    /// ������ ������
    /// </summary>
    private Rigidbody _censer_rb;
    /// <summary>
    /// ���� ����������� ������
    /// </summary>
    public AudioSource reload_audio;
    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    public AudioSource holyFire_audio;
    /// <summary>
    /// ���� ������ ��������
    /// </summary>
    public AudioSource take_audio;

    /// <summary>
    /// ������� ��� ��������� UI ������� ����
    /// </summary>
    public UnityEvent UIFire;
    /// <summary> 
    /// ������� ��� UI ������� ����������� 
    /// </summary> 
    public UnityEvent UITimerReload;
    /// <summary>
    /// �������� ������
    /// </summary>
    private Animator _anim_pl;

    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    private bool _flag_active_censer = false;
    /// <summary>
    /// ���� ������ ������
    /// </summary>
    public bool flag_take_censer = false;
    /// <summary>
    /// ���� ��������������� ������
    /// </summary>
    public bool flag_reload = true;

    /// <summary>
    /// ����� �������� ������
    /// </summary>
    public float time_holyfire = 60f;
    public float timer;
    /// <summary>
    /// ���-�� ������
    /// </summary>
    public int mirrh_count;

    private void Awake()
    {
        _censer_rb = _censer.GetComponent<Rigidbody>();
        _anim_pl = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        timer = time_holyfire;
    }

    private void Update()
    {
        if (flag_take_censer)
        {
            Censer_Active();
            Fare();
            Reload();
        }
    }

    public void Take_Censer()
    {
        flag_take_censer = true;
    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    private void Censer_Active()
    {
        if (!_flag_active_censer)
        {
            _Right_hand.Rotate(-120f, 0, 0, Space.Self);
            _chains.SetActive(true);
            _censer.SetActive(true);
            _flag_active_censer = true;
        }
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    private void Fare()
    {
        if (Input.GetMouseButtonDown(0) && flag_reload && !_holy_fire.activeSelf)
        {
            Debug.Log("holy_fire!");
            holyFire_audio.Play();
            _holy_fire.SetActive(true);
            UIFire?.Invoke();
        }

        if (_holy_fire.activeSelf)
        {
            if(timer <= 0)
            {
                flag_reload = false;
                _holy_fire.SetActive(false);
                //���������� ����� � �������� � ������
                _pointlight.SetActive(false); 
                _particle.SetActive(false);
                holyFire_audio.Stop();

                UIFire?.Invoke();
                timer = time_holyfire;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// ����������� ������
    /// </summary>
    private void Reload()
    {
        if (!flag_reload && mirrh_count > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                reload_audio.Play();
                UITimerReload?.Invoke();
                _anim_pl.SetTrigger("Reload");
                _censer_rb.isKinematic = false;
                mirrh_count--;
            }
        }
    }

    /// <summary>
    /// ��� ������� �������� � ����� �����������
    /// </summary>
    public void Reload_End()
    {
        UITimerReload?.Invoke();
        //��������� ����� � �������� � ������
        _pointlight.SetActive(true);
        _particle.SetActive(true);

        flag_reload = true;
    }

    /// <summary>
    /// ���������� ������ ������
    /// </summary>
    public void PhysicsOff()
    {
        _censer_rb.isKinematic = true;
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    public void TakeMirrh()
    {
        mirrh_count++;
        take_audio?.Play();
        _anim_pl.SetTrigger("TakeMirrh");
    }
}
