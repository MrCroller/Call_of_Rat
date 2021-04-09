using UnityEngine;
using UnityEngine.Events;

public class Hand_Trigger : MonoBehaviour
{
    public UnityEvent story;
    public bool flag = true;


    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("trigger_hand") && flag)
        {
            flag = false;
            Debug.Log("Player_trigger_Hand");

            story?.Invoke();
        }
    }
}
