using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] GameObject door;

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("trigger_enter");
        if (col.tag == "trigger_hand")
        {
            Debug.Log("Button");
            door.GetComponent<door>().button_flag = true;
        }

    }
}
