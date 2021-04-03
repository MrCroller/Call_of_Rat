using UnityEngine;

public class Start_story : MonoBehaviour
{
    [SerializeField] private Storyteller _storyteller;
    public bool flag_start_story = true;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("area_startroom_trigger");
        if (col.tag == "Player" && flag_start_story)
        {
            flag_start_story = false;
            Debug.Log("Player_trigger_startroom");

            _storyteller.Start_story();
        }
    }
}
