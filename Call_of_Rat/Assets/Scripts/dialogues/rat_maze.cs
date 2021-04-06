using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rat_maze : MonoBehaviour
{
    [SerializeField] public TextMeshPro text_mesh_ratmaze;
    [SerializeField] public Transform text_rot;
    /// <summary>
    /// ���� ��� ��������
    /// </summary>
    [SerializeField] private Transform _target;

    /// <summary>
    /// ��������� ����� ��� �������
    /// </summary>
    private List<string> startStory_text;

    private void Awake()
    {
        startStory_text = new List<string>()
        {
            "��� �� � �������� ���������",
            "������� � ��� �����?",
            "�������� ���� ������ ����� � �����",
            "� �������� ��� ����� �������������",
            "����, ���� �������",
            "����� ��������� ������� ��������?",
        };

    }

    private void FixedUpdate()
    {
        TextRotation();
    }

    /// <summary>
    /// ������� ������ �������
    /// </summary>
    public void MazeStory_Event()
    {
        StartCoroutine(MazeStory());
    }

    /// <summary>
    /// ������� ���������
    /// </summary>
    /// <returns></returns>
    private IEnumerator MazeStory()
    {
        while (true)
        {
            foreach (string s in startStory_text)
            {
                yield return new WaitForSeconds(Random.Range(3f, 3.5f));
                text_mesh_ratmaze.text = "";
                yield return new WaitForSeconds(Random.Range(3f, 4f));
                text_mesh_ratmaze.text = s;
            }
        }
    }

    /// <summary>
    /// ������� ������ � ������� ����
    /// </summary>
    private void TextRotation()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 6, 0);
        text_rot.rotation = Quaternion.LookRotation(-newDir);
    }
}
