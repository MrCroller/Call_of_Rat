using UnityEngine;

public class Exit_start_story : MonoBehaviour
{
    [SerializeField] private Storyteller _storyteller;
    public bool flag_start_story = true;


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("area_exitstartroom_trigger");
        if (col.tag == "Player" && flag_start_story)
        {
            flag_start_story = false;
            Debug.Log("Player_trigger_exitstartroom");

            _storyteller.Exit_start_story();
        }
    }
}
