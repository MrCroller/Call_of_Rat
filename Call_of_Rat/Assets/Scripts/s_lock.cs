using UnityEngine;

public class s_lock : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _plight;
    private static int key_count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger_hand")
        {
            Debug.Log("Touch_secret_lock");

            if (_player.GetComponent<player>().key_count > 0 && !gameObject.GetComponent<MeshRenderer>().enabled)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                _plight.SetActive(true);

                _player.GetComponent<player>().key_count--;
                key_count++;

                if (key_count == 5) _door.GetComponent<door>().button_flag = true;
            }
        }
    }
}
