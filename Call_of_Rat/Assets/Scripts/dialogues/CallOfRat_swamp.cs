using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class CallOfRat_swamp : MonoBehaviour
{
    /// <summary>
    /// Mesh �������
    /// </summary>
    public TextMeshPro[] text_mesh;
    /// <summary>
    /// ������� �������
    /// </summary>
    public Transform[] text_rot;
    /// <summary>
    /// ���� ��� ��������
    /// </summary>
    public Transform target;
    /// <summary>
    /// ���� �������� �������
    /// </summary>
    private bool flag_text_rot = false;

    /// <summary>
    /// ��� ������ ������
    /// </summary>
    public List<string> fileColName;
    /// <summary>
    /// �����
    /// </summary>
    private List<List<string>> textArray;
    /// <summary>
    /// ����� � ������� ���� � �������
    /// </summary>
    private int[] rat_num;

    private void Awake()
    {
        rat_num = new int[] { 0, 1, 2, 0, 0, 1 };
        textArray = new List<List<string>>();
        TextPull(fileColName);
    }

    private void FixedUpdate()
    {
        // �� ��� �� ������ ��� �� ���������
        if(flag_text_rot) TextRotation();
    }

    /// <summary>
    /// ���������� ������� ������ �������
    /// </summary>
    public void Startstory_Event()
    {
        flag_text_rot = true;
        StopAllCoroutines();
        StartCoroutine(Story(0));
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="story_num">����� ��������� ������</param>
    /// <param name="mesh_num">����� ���������� ����</param>
    /// <returns></returns>
    private IEnumerator Story(int story_num)
    {
        int i = 0;
        foreach (string text in textArray[story_num])
        {
            text_mesh[rat_num[i]].text = text;
            yield return new WaitForSeconds(TextPouse(text));
            text_mesh[rat_num[i]].text = null;
            i++;
        }
    }

    /// <summary>
    /// ����� ����������� ����� ����� ������
    /// </summary>
    /// <param name="s">����� ��� ����������� �����</param>
    /// <returns></returns>
    private float TextPouse(string s)
    {
        float pouse = s.Length * 0.125f; //������������ ����� �� �����
        if (pouse < 1f) return Random.Range(1f, 1.5f);
        if (pouse > 4.5f) return Random.Range(4.2f, 5f);
        else return pouse;
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
    /// ������� ������ � ������� ����
    /// </summary>
    private void TextRotation()
    {
        foreach (Transform text_r in text_rot)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 6, 0);
            text_r.rotation = Quaternion.LookRotation(-newDir);
        }
    }
}

