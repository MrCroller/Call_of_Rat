using UnityEngine;
using UnityEngine.Events;

public class S_lock : MonoBehaviour
{
    [SerializeField] private Player _player;
    /// <summary>
    /// ����������� �����
    /// </summary>
    [SerializeField] private GameObject _plight;
    /// <summary>
    /// ������ �� �������� �����
    /// </summary>
    public Animator door;
    /// <summary>
    /// ���-�� �������������� ������
    /// </summary>
    private static int key_count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger_hand"))
        {
            Debug.Log("Touch_secret_lock");

            if (_player.key_count > 0 && !gameObject.GetComponent<MeshRenderer>().enabled)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                _plight.SetActive(true);

                _player.key_count--;
                key_count++;

                if (key_count == 5)
                {
                    door.SetBool("Open", true);
                }
            }
        }
    }
}
