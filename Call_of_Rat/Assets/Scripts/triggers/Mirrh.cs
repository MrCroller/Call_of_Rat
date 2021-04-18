using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mirrh : MonoBehaviour
{
    public UnityEvent take;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger_hand") && gameObject.activeSelf)
        {
            Debug.Log("take_mirrh");

            gameObject.SetActive(false);
            take?.Invoke();
        }
    }
}

