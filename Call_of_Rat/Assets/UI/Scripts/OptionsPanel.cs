using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu.UI
{
    public class OptionsPanel : MonoBehaviour
    {
        /// <summary>
        /// ������ �� ������ ���������� �������
        /// </summary>
        public Player_controller player;

        /// <summary>
        /// �������� ����������� ���������������
        /// </summary>
        [SerializeField] private InputField field_sens;
        /// <summary>
        /// �������� ����������� ����� ���������
        /// </summary>
        [SerializeField] private InputField field_vol;
        /// <summary>
        /// �������� ����������� ��������� ��������
        /// </summary>
        [SerializeField] private InputField field_Eff_vol;
        /// <summary>
        /// �������� ����������� ��������� ������
        /// </summary>
        [SerializeField] private InputField field_Music_vol;
        /// <summary>
        /// ������ ������� ������
        /// </summary>
        [SerializeField] private AudioMixerGroup mixer;

        public void Start()
        {
            field_sens.text = player.sensivity.ToString();
            field_vol.text = "1";
            field_Eff_vol.text = "1";
            field_Music_vol.text = "1";
        }

        /// <summary>
        /// ��������� ����������������
        /// </summary>
        /// <param name="value"></param>
        public void ChangeSensetivity(float value)
        {
            player.sensivity = Mathf.Lerp(0.01f, 10f, value);
            field_sens.text = (value * 10).ToString();
        }

        /// <summary>
        /// ��������� �������� ��������� ���������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeMasterVolume(float volume)
        {
            mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
            field_vol.text = volume.ToString();
        }

        /// <summary>
        /// ��������� ��������� ��������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeEffectVolume(float volume)
        {
            mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
            field_Eff_vol.text = volume.ToString();
        }

        /// <summary>
        /// ��������� ��������� ������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeMusicVolume(float volume)
        {
            mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
            field_Music_vol.text = volume.ToString();
        }

        /// <summary>
        /// ������������� ��������� ������ � ������
        /// </summary>
        /// <param name="enabled"></param>
        public void ToggleROFL(bool enabled)
        {
            mixer.audioMixer.SetFloat("ROFLVolume", enabled ? 0 : -80);
        }
    }
}
