using UnityEngine;

public class Pasta_tr : MonoBehaviour
{
    [SerializeField] private Rat_st _rat_st;
    public bool flag_start_story = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("area_pasta_trigger");
        if (col.tag == "Player" && !flag_start_story)
        {
            Debug.Log("Player_trigger_pasta");
            flag_start_story = true;

            _rat_st.Pasta();
        }
    }
}
