using UnityEngine;

public class take : MonoBehaviour
{
    [SerializeField] private GameObject go;
    public bool flag_take = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("take_trigger");
        if (col.tag == "Player" && !flag_take)
        {
            flag_take = true;
            go.GetComponent<censer>().Take();
        }
    }
}
