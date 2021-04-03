using UnityEngine;

public class Maze_story_tr : MonoBehaviour
{
    [SerializeField] private Rat_maze _rat_maze;
    public bool flag_start_story = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("area_ratmaze_trigger");
        if (col.tag == "Player" && !flag_start_story)
        {
            Debug.Log("Player_trigger_ratmaze");
            flag_start_story = true;

            _rat_maze.MazeStory();
        }
    }
}
