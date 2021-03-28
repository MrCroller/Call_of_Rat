using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _start_story;

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("trigger_enter");
        if (col.tag == "trigger_hand")
        {
            Debug.Log("Button");

            // ���� ��� �������� �����
            _door.GetComponent<door>().button_flag = true;

            // ������ ���������� ������� ��-�� �������� �����
            _start_story.GetComponent<start_story>().flag_start_story = false;
        }

    }
}
