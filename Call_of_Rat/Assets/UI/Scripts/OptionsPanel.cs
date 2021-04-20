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

        [SerializeField] private InputField field_vol;
        [SerializeField] private InputField field_sens;
        /// <summary>
        /// ������ ������� ������
        /// </summary>
        [SerializeField] private AudioMixerGroup mixer;

        /// <summary>
        /// ��������� ����������������
        /// </summary>
        /// <param name="value"></param>
        public void ChangeSensetivity(float value)
        {
            player.sensivity = Mathf.Lerp(0.01f, 10f, value);
        }

        /// <summary>
        /// ��������� �������� ��������� ���������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeMasterVolume(float volume)
        {
            mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        }

        /// <summary>
        /// ��������� ��������� ��������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeEffectVolume(float volume)
        {
            mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        }

        /// <summary>
        /// ��������� ��������� ������
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeMusicVolume(float volume)
        {
            mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
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
