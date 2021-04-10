using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    /// <summary>
    /// Цель поворота
    /// </summary>
    [SerializeField] private Transform _target;
    /// <summary>
    /// Скорость поворота
    /// </summary>
    [SerializeField] private float dirSpeed;
    /// <summary>
    /// Текст диалога
    /// </summary>
    [SerializeField] public TextMeshPro text_mesh;

    /// <summary>
    /// Точки перемещения рассказчика
    /// </summary>
    public Transform[] points;

    /// <summary>
    /// Имя файлов текста
    /// </summary>
    public List<string> fileColName;
    /// <summary>
    /// Текст
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
    /// Реализация события начала истории
    /// </summary>
    public void Startstory_Event()
    {
        StopAllCoroutines();
        StartCoroutine(Story(0));
    }

    /// <summary>
    /// Реализация события выхода из комнаты
    /// </summary>
    public void Exitstory_Event()
    {
        StopAllCoroutines();
        StartCoroutine(Story(1));
    }

    /// <summary>
    /// Событие перемещения рассказчика к конкретной точке
    /// </summary>
    /// <param name="i">Номер точки в массиве</param>
    public void Transfer(int i)
    {
        StopAllCoroutines();
        text_mesh.text = "";
        transform.position = points[i].position;
    }

    /// <summary>
    /// Рассказ
    /// </summary>
    /// <param name="i">Номер коллекции текста</param>
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
    /// Повторяющийся рассказ
    /// </summary>
    /// <param name="i">Номер коллекции текста</param>
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
    /// Метод определения паузы после текста
    /// </summary>
    /// <param name="s">Текст для определения паузы</param>
    /// <returns></returns>
    private float TextPouse(string s)
    {
        float pouse = s.Length * 0.130f; //Длительность паузы на букву
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
    /// Поворот на игрока
    /// </summary>
    private void VissiblePlayer()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, dirSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
