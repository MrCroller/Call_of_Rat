using UnityEngine;

public class Test : MonoBehaviour
{

    private void OnTriggerEnter()
    {
        print("Enter");
    }

    private void OnTriggerStay()
    {
        print("Stay");
    }

    private void OnTriggerExit()
    {
        print("Exit");
    }
}
