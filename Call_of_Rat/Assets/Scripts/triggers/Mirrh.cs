using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mirrh : MonoBehaviour
{
    public UnityEvent take;
    /// <summary>
    /// Звук взятия предмета
    /// </summary>
    public AudioSource audio_s;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger_hand") && gameObject.activeSelf)
        {
            Debug.Log("take_mirrh");

            audio_s?.Play();
            gameObject.SetActive(false);
            take?.Invoke();
        }
    }
}

