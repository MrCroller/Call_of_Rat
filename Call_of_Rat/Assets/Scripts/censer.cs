using UnityEngine;

public class censer : MonoBehaviour
{
    [SerializeField] private float _speed_an;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _censer;
    public bool take_go = false;

    private void Update()
    {
        if (!take_go)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), _speed_an * Time.deltaTime);
        }
    }

    /// <summary>
    /// Взятие кадила
    /// </summary>
    public void Take()
    {
        Debug.Log("Take_censer");
        take_go = true;
        _player.GetComponent<player>().flag_take_censer = true;
        _censer.SetActive(false);
    }
}
