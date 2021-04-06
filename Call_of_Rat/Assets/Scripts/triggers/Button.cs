using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    /// <summary>
    /// ������� �������� �����
    /// </summary>
    public UnityEvent open;

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("trigger_enter");
        if (col.CompareTag("trigger_hand"))
        {
            Debug.Log("Button");

            open?.Invoke();
        }

    }
}
