using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Censer_Player : MonoBehaviour
{
    /// <summary>
    /// Правая рука
    /// </summary>
    [SerializeField] private Transform _Right_hand;
    /// <summary>
    ///  Святое оружие
    /// </summary>
    [SerializeField] private GameObject _censer;
    /// <summary>
    /// Цепи
    /// </summary>
    [SerializeField] private GameObject _chains;
    /// <summary>
    /// Эффекты заряженного кадила
    /// </summary>
    [SerializeField] private GameObject _particle;
    /// <summary>
    /// Священный огонь (выстрел)
    /// </summary>
    [SerializeField] private GameObject _holy_fire;

    /// <summary>
    /// Событие для активации UI эффекта огня
    /// </summary>
    public UnityEvent UIFire;
    /// <summary>
    /// Аниматор игрока
    /// </summary>
    private Animator _anim_pl;

    /// <summary>
    /// Флаг активации оружия
    /// </summary>
    private bool _flag_active_censer = false;
    /// <summary>
    /// Флаг взятия оружия
    /// </summary>
    public bool _flag_take_censer = false;
    /// <summary>
    /// Флаг перезаряженного кадила
    /// </summary>
    public bool flag_reload = true;

    /// <summary>
    /// Время действия кадила
    /// </summary>
    public float time_holyfire = 10f;
    public float timer;
    /// <summary>
    /// Кол-во ладана
    /// </summary>
    public int mirrh_count;

    private void Awake()
    {
        _anim_pl = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        timer = time_holyfire;
    }

    private void Update()
    {
        if (_flag_take_censer)
        {
            Censer_Active();
            Fare();
            Reload();
        }
    }

    public void Take_Censer()
    {
        _flag_take_censer = true;
    }

    /// <summary>
    /// Активация оружия
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
    /// Логика оружия
    /// </summary>
    private void Fare()
    {
        if (Input.GetMouseButtonDown(0) && flag_reload)
        {
            Debug.Log("holy_fire!");
            _holy_fire.SetActive(true);
            UIFire?.Invoke();
        }

        if (_holy_fire.activeSelf)
        {
            if(timer <= 0)
            {
                _holy_fire.SetActive(false);
                flag_reload = false;
                _particle.SetActive(false);
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
    /// Перезарядка оружия
    /// </summary>
    private void Reload()
    {
        if (!flag_reload && mirrh_count > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _anim_pl.SetTrigger("Reload");
                mirrh_count--;
            }
        }
    }

    /// <summary>
    /// Для события анимации в конце перезарядки
    /// </summary>
    public void Reload_End()
    {
        _particle.SetActive(true);
        flag_reload = true;
    }
}
