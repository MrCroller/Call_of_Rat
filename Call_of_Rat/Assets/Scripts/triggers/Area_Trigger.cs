using UnityEngine;
using UnityEngine.Events;

public class Area_Trigger : MonoBehaviour
{
    public UnityEvent story;
    public bool flag = true;


    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("area_exitstartroom_trigger");
        if (col.CompareTag("Player") && flag)
        {
            flag = false;
            Debug.Log("Player_trigger_Area");

            story?.Invoke();
        }
    }
}
