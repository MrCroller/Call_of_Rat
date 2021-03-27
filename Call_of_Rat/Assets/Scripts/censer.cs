using UnityEngine;

public class censer : MonoBehaviour
{
    [SerializeField] private float _speed_an;

    private void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), _speed_an * Time.deltaTime);
    }
}
