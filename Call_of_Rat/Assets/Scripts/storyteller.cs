using UnityEngine;

public class storyteller : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float dirSpeed;
    [SerializeField] public GameObject text;

    private void FixedUpdate()
    {
        Vector3 dir = _target.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, dirSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("WTF_trigger");
        if(col.tag == "Player")
        {
            Debug.Log("Player_trigger_storyteller");
            Start_Story();
        }
    }

    private void Start_Story()
    {
        text.GetComponent<TextEditor>().text = "Привет, залетный!";
    }
}
