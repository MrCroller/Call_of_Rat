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
    /// <summary>
    /// Изображение ладана
    /// </summary>
    public Image mirrh_image;

    private void Update()
    {
        timer_r.fillAmount = censer.timer / 10f;
        if (censer._flag_take_censer && gameObject.activeSelf) ui.SetActive(true);
        if (censer.flag_reload && mirrh_image.fillAmount < 1f) mirrh_image.fillAmount = 1f;
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
}
