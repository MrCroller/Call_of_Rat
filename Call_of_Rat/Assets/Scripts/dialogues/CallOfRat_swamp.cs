using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class CallOfRat_swamp : MonoBehaviour
{
    /// <summary>
    /// Mesh текстов
    /// </summary>
    public TextMeshPro[] text_mesh;
    /// <summary>
    /// Позиции текстов
    /// </summary>
    public Transform[] text_rot;
    /// <summary>
    /// Цель для поворота
    /// </summary>
    public Transform target;
    /// <summary>
    /// Флаг поворота текстау
    /// </summary>
    private bool flag_text_rot = false;

    /// <summary>
    /// Имя файлов текста
    /// </summary>
    public List<string> fileColName;
    /// <summary>
    /// Текст
    /// </summary>
    private List<List<string>> textArray;
    /// <summary>
    /// Номер и порядок крыс в диалоге
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
        // ну что бы лишний раз не крутилось
        if(flag_text_rot) TextRotation();
    }

    /// <summary>
    /// Реализация события начала истории
    /// </summary>
    public void Startstory_Event()
    {
        flag_text_rot = true;
        StopAllCoroutines();
        StartCoroutine(Story(0));
    }

    /// <summary>
    /// Рассказ
    /// </summary>
    /// <param name="story_num">Номер коллекции текста</param>
    /// <param name="mesh_num">Номер текстового меша</param>
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
    /// Метод определения паузы после текста
    /// </summary>
    /// <param name="s">Текст для определения паузы</param>
    /// <returns></returns>
    private float TextPouse(string s)
    {
        float pouse = s.Length * 0.125f; //Длительность паузы на букву
        if (pouse < 1f) return Random.Range(1f, 1.5f);
        if (pouse > 4.5f) return Random.Range(4.2f, 5f);
        else return pouse;
    }

    /// <summary>
    /// Заполнение коллекции строк из файла
    /// </summary>
    private List<string> FileReader(string fileName)
    {
        string readFromFilePatch = Application.streamingAssetsPath + "/Text/" + fileName + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePatch).ToList();
        return fileLines;
    }

    /// <summary>
    /// Заполнение коллекций текста
    /// </summary>
    private void TextPull(List<string> filesName)
    {
        foreach (string f_name in filesName)
        {
            textArray.Add(FileReader(f_name));
        }
    }

    /// <summary>
    /// Поворот текста в сторону цели
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

