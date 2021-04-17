using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_UI : MonoBehaviour
{
    /// <summary>
    /// Таймер активности 
    /// </summary>
    public Image timer_r;
    /// <summary>
    /// Изображение ладана
    /// </summary>
    public Image mirrh_image;
    /// <summary>
    /// Скрипт оружия игрока
    /// </summary>
    public Censer_Player censer;
    /// <summary>
    /// UI элементы оружия
    /// </summary>
    public GameObject ui;
    /// <summary>
    /// Партиклы эффекта огня
    /// </summary>
    public GameObject fire;

    public Text mirh_countTXT;
    /// <summary>
    /// Кол-во ладана
    /// </summary>
    private int mirh;

    /// <summary> 
    /// Флаг перезарядки таймера
    /// </summary> 
    private bool flag_reload_UI = false;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (censer.flag_take_censer)
        {
            // Активация UI оружия 
            if (!ui.activeSelf) ui.SetActive(true);

            // Таймер длительности горения
            if (censer.flag_reload) timer_r.fillAmount = censer.timer / 10f;
            // Активация изображение ладана после перезарядки 
            if (censer.flag_reload && mirrh_image.fillAmount < 1f) mirrh_image.fillAmount = 1f;
            // Анимация таймера для перезарядки (таймер выставлен с расчетом на 3 секунды анимации) 
            if (!censer.flag_reload && flag_reload_UI) timer_r.fillAmount += Time.deltaTime * 0.25f;

            mirh_countTXT.text = $"{censer.mirrh_count}X";
        }
    }

    /// <summary>
    /// UI Активация эффекта огня
    /// </summary>
    public void Fire_UI()
    {
        if (censer.timer > 0 && !fire.activeSelf)
        {
            Debug.Log("fire_UI_true");
            fire.SetActive(true);
        }
        else if (censer.timer < 0 && fire.activeSelf)
        {
            Debug.Log("fire_UI_false");
            mirrh_image.fillAmount = 0f;
            fire.SetActive(false);
        }
    }

    /// <summary> 
    /// UI переключатель таймера перезарядки 
    /// </summary> 
    public void Timer_Reload()
    {
        flag_reload_UI = !flag_reload_UI;
    }
}
