using UnityEngine;

public class key : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger_hand")
        {
            Debug.Log("take_key");

            _player.GetComponent<player>().key_count++;
            gameObject.SetActive(false);
        }
    }
}
