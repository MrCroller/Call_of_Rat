using UnityEngine;
using UnityEngine.Events;

public class Censer : MonoBehaviour
{
    [SerializeField] private GameObject _censer;
    public UnityEvent take;
    //public bool flag = true;
    public AudioSource audio_s;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && _censer.activeSelf)
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
        audio_s?.Play();
        take?.Invoke();
        _censer.SetActive(false);
    }
}
