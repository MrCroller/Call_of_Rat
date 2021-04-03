using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger_hand")
        {
            Debug.Log("take_key");

            _player.key_count++;
            gameObject.SetActive(false);
        }
    }
}
