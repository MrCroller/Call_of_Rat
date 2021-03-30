using UnityEngine;

public class maze_story_tr : MonoBehaviour
{
    [SerializeField] private GameObject _rat_maze;
    public bool flag_start_story = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("area_ratmaze_trigger");
        if (col.tag == "Player" && !flag_start_story)
        {
            Debug.Log("Player_trigger_ratmaze");
            flag_start_story = true;

            _rat_maze.GetComponent<rat_maze>().MazeStory();
        }
    }
}
