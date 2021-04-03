using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Start_story _start_story_trigger;

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("trigger_enter");
        if (col.tag == "trigger_hand")
        {
            Debug.Log("Button");

            // Флаг для открытия двери
            _door.button_flag = true;

            // Отмена начального диалога из-за открытия двери
            _start_story_trigger.flag_start_story = false;
        }

    }
}
