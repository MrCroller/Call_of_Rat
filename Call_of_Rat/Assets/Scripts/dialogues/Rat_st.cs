using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;


public class Rat_st : MonoBehaviour
{
    /// <summary>
    /// Крысы для разговоров
    /// </summary>
    [SerializeField] public TextMeshPro[] text_mesh;

    /// <summary>
    /// Имя файлов текста
    /// </summary>
    public List<string> fileColName;
    /// <summary>
    /// Текст
    /// </summary>
    private List<List<string>> textArray;
    /// <summary>
    /// Номер истории
    /// </summary>
    private int st_num = 0;

    private void Awake()
    {
        textArray = new List<List<string>>();
        TextPull(fileColName);
    }

    /// <summary>
    /// Реализация события начала истории
    /// </summary>
    public void Startstory_Event()
    {
        StopAllCoroutines();
        ST_Story_Method();
    }

    // Костыльный метод по правильной последовательности историй
    private void ST_Story_Method()
    {

        if (st_num == 0)
        {
            StartCoroutine(Story(0, 0));
        }

        if (st_num == 1)
        {
            StopAllCoroutines();
            StartCoroutine(Story(1, 1));
        }
        else if (st_num == 2)
        {
            StopAllCoroutines();
            StartCoroutine(Story(2, 3));
        }
        else if (st_num == 3)
        {
            StopAllCoroutines();
            StartCoroutine(Story(3, 3));
        }
        else if (st_num == 4)
        {
            StopAllCoroutines();
            StartCoroutine(Story(4, 1));
        }
        else if (st_num == 5)
        {
            StopAllCoroutines();
            StartCoroutine(Story(5, 3));
        }
        else if (st_num == 6)
        {
            StopAllCoroutines();
            StartCoroutine(Story(6, 2));
            st_num = 0;
        }
        st_num++;
    }

    /// <summary>
    /// Рассказ
    /// </summary>
    /// <param name="story_num">Номер коллекции текста</param>
    /// <param name="mesh_num">Номер текстового меша</param>
    /// <returns></returns>
    private IEnumerator Story(int story_num, int mesh_num)
    {
        foreach (string text in textArray[story_num])
        {
            text_mesh[story_num].text = "";
            foreach (char letter in text.ToCharArray())
            {
                text_mesh[story_num].text += letter;
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(TextPouse(text));
        }
        ST_Story_Method();
    }

    /// <summary>
    /// Метод определения паузы после текста
    /// </summary>
    /// <param name="s">Текст для определения паузы</param>
    /// <returns></returns>
    private float TextPouse(string s)
    {
        float pouse = s.Length * 0.100f; //Длительность паузы на букву
        if (pouse < 1f)
        {
            return Random.Range(1f, 1.5f);
        }

        if (pouse > 4.5f)
        {
            return Random.Range(4.2f, 5f);
        }
        else
        {
            return pouse;
        }
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
}
