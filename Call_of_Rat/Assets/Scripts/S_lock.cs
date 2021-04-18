using UnityEngine;
using UnityEngine.Events;

public class S_lock : MonoBehaviour
{
    [SerializeField] private Player _player;
    /// <summary>
    /// Отображение ключа
    /// </summary>
    [SerializeField] private GameObject _plight;
    /// <summary>
    /// Ссылка на аниматор двери
    /// </summary>
    public Animator door;
    /// <summary>
    /// Кол-во активированных ключей
    /// </summary>
    private static int key_count = 0;
    /// <summary>
    /// Рендер вставленных ключей
    /// </summary>
    private MeshRenderer key_active;

    public AudioSource audio_door;
    private AudioSource _audio_key;

    private void Awake()
    {
        _audio_key = gameObject.GetComponent<AudioSource>();
        key_active = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger_hand"))
        {
            Debug.Log("Touch_secret_lock");

            if (_player.key_count > 0 && !key_active.enabled)
            {
                key_active.enabled = true;
                _plight.SetActive(true);

                _audio_key.Play();

                _player.key_count--;
                key_count++;

                if (key_count == 5)
                {
                    audio_door.Play();
                    door.SetBool("Open", true);
                }
            }
        }
    }
}
