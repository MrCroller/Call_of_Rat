using UnityEngine;

public class Censer : MonoBehaviour
{
    /// <summary>
    /// �������� ��������
    /// </summary>
    public float speed_an;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _censer;
    public bool take_go = false;

    private void Update()
    {
        if (!take_go)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), speed_an * Time.deltaTime);
        }
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    public void Take()
    {
        Debug.Log("Take_censer");
        take_go = true;
        _player.flag_take_censer = true;
        _censer.SetActive(false);
    }
}
