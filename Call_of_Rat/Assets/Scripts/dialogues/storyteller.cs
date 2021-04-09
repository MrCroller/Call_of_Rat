using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    /// <summary>
    /// ���� ��������
    /// </summary>
    [SerializeField] private Transform _target;
    /// <summary>
    /// �������� ��������
    /// </summary>
    [SerializeField] private float dirSpeed;
    /// <summary>
    /// ����� �������
    /// </summary>
    [SerializeField] public TextMeshPro text_mesh;

    /// <summary>
    /// ����� ����������� �����������
    /// </summary>
    public Transform[] points;

    /// <summary>
    /// ��� ������ ������
    /// </summary>
    public List<string> fileColName;
    /// <summary>
    /// �����
    /// </summary>
    private List<List<string>> textArray;

    private void Awake()
    {
        textArray = new List<List<string>>();
        TextPull(fileColName);
    }

    private void FixedUpdate()
    {
        VissiblePlayer();
    }

    /// <summary>
    /// ���������� ������� ������ �������
    /// </summary>
    public void Startstory_Event()
    {
        StopAllCoroutines();
        StartCoroutine(Story(0));
    }

    /// <summary>
    /// ���������� ������� ������ �� �������
    /// </summary>
    public void Exitstory_Event()
    {
        StopAllCoroutines();
        StartCoroutine(Story(1));
    }

    /// <summary>
    /// ������� ����������� ����������� � ���������� �����
    /// </summary>
    /// <param name="i">����� ����� � �������</param>
    public void Transfer(int i)
    {
        StopAllCoroutines();
        text_mesh.text = "";
        transform.position = points[i].position;
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="i">����� ��������� ������</param>
    /// <returns></returns>
    private IEnumerator Story(int i)
    {
        foreach (string text in textArray[i])
        {
            text_mesh.text = text;
            yield return new WaitForSeconds(TextPouse(text));
        }
    }

    /// <summary>
    /// ������������� �������
    /// </summary>
    /// <param name="i">����� ��������� ������</param>
    /// <returns></returns>
    private IEnumerator WoidTalk(int i)
    {
        while (true)
        {
            foreach (string text in textArray[i])
            {
                text_mesh.text = "";
                yield return new WaitForSeconds(Random.Range(2.6f, 3.3f));
                text_mesh.text = text;
                yield return new WaitForSeconds(TextPouse(text));
            }
        }
    }

    /// <summary>
    /// ����� ����������� ����� ����� ������
    /// </summary>
    /// <param name="s">����� ��� ����������� �����</param>
    /// <returns></returns>
    private float TextPouse(string s)
    {
        float pouse = s.Length * 0.130f; //������������ ����� �� �����
        if (pouse > 5f)
        {
            return 5f;
        }
        else
        {
            return pouse;
        }
    }

    /// <summary>
    /// ���������� ��������� ����� �� �����
    /// </summary>
    private List<string> FileReader(string fileName)
    {
        string readFromFilePatch = Application.streamingAssetsPath + "/Text/" + fileName + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePatch).ToList();
        return fileLines;
    }

    /// <summary>
    /// ���������� ��������� ������
    /// </summary>
    private void TextPull(List<string> filesName)
    {

        foreach (string f_name in filesName)
        {
            textArray.Add(FileReader(f_name));
        }
    }

    /// <summary>
    /// ������� �� ������
    /// </summary>
    private void VissiblePlayer()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, dirSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
