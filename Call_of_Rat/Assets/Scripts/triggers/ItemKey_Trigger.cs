using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemKey_Trigger : MonoBehaviour
{
    public UnityEvent take;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("player");
        take.AddListener(player.GetComponent<Player>().TakeKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger_hand") && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Debug.Log("take_loot");
            Destroy(gameObject);
            take?.Invoke();
        }
    }
}
