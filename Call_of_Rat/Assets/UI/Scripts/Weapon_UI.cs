using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_UI : MonoBehaviour
{
    /// <summary>
    /// ������ ���������� 
    /// </summary>
    public Image timer_r;
    /// <summary>
    /// ������ ������ ������
    /// </summary>
    public Censer_Player censer;
    /// <summary>
    /// UI �������� ������
    /// </summary>
    public GameObject ui;
    /// <summary>
    /// �������� ������� ����
    /// </summary>
    public GameObject fire;
    /// <summary>
    /// ����������� ������
    /// </summary>
    public Image mirrh_image;

    private void Update()
    {
        timer_r.fillAmount = censer.timer / 10f;
        if (censer._flag_take_censer && gameObject.activeSelf) ui.SetActive(true);
        if (censer.flag_reload && mirrh_image.fillAmount < 1f) mirrh_image.fillAmount = 1f;
    }

    /// <summary>
    /// UI ��������� ������� ����
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
