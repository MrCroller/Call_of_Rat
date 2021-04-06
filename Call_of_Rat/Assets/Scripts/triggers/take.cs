using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField] private Censer _censer;
    public bool flag_take = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("take_trigger");
        if (col.CompareTag("Player") && !flag_take)
        {
            flag_take = true;
            _censer.Take();
        }
    }
}
