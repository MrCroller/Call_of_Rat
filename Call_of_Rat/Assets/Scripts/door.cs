using UnityEngine;

public class door : MonoBehaviour
{
    // ������ �������� �����
    [SerializeField] public GameObject key;

    [SerializeField] private GameObject _lock;
    [SerializeField] private Transform _sash;
    [SerializeField] private Transform _door;
    private Vector3 _openPosition_sash;
    private Quaternion _openPosition_door;
    public bool button_flag = false;

    private void Start()
    {
        // ��������� ������� �������� �������
        _openPosition_sash = _sash.position + new Vector3(0, 0, 0.35f);

        // ��������� ������� �������� �����
        _openPosition_door = _door.rotation * Quaternion.Euler(0f, -80f, 0f);
    }

    private void FixedUpdate()
    {
        if (button_flag)
        {
            Open();
        }
    }

    /// <summary>
    /// ����� �������� �����
    /// </summary>
    public void Open()
    {
        // ������ �����
        _lock.SetActive(false);

        // �������� �������
        //_sash.position = Vector3.MoveTowards(_sash.position, openPosition, 0.3f * Time.deltaTime);

        // ������� �����
        //if (_sash.position == openPosition)
        //{
        _door.rotation = Quaternion.SlerpUnclamped(_door.rotation, _openPosition_door, 0.6f * Time.deltaTime);
        //}

        if (_door.rotation == _openPosition_door)
        {
            button_flag = false;
            Debug.Log("open");
        }
    }
}
