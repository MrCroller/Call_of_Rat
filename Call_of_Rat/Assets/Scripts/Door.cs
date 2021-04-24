using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _flag_door_open = false;
    public AudioSource audio_s;
    public Animator animator_door;
    private Animator _button;

    private void Awake()
    {
        _button = GetComponent<Animator>();
    }

    public void Press()
    {
        _flag_door_open = true;
        audio_s.Play();
        _button.SetBool("Press", _flag_door_open);
    }

    public void Open()
    {
        animator_door.SetBool("Open", _flag_door_open);
    }
}
