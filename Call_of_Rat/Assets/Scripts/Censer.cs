using UnityEngine;
using UnityEngine.Events;

public class Censer : MonoBehaviour
{
    [SerializeField] private GameObject _censer;
    public UnityEvent take;
    public bool flag = true;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && flag)
        {
            Take();
        }
    }

    /// <summary>
    /// Взятие кадила
    /// </summary>
    public void Take()
    {
        Debug.Log("Take_censer");
        take?.Invoke();
        _censer.SetActive(false);
    }
}
