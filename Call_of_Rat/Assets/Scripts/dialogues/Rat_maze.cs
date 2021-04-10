using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Rat_maze : MonoBehaviour
{
    public TextMeshPro _text_mesh;
    [SerializeField] public Transform text_rot;
    /// <summary>
    /// Цель для поворота
    /// </summary>
    [SerializeField] private Transform _target;

    /// <summary>
    /// Имя файлов текста
    /// </summary>
    public List<string> fileName;

    /// <summary>
    /// Начальный текст при встрече
    /// </summary>
    private List<string> textArray;

    private void Awake()
    {
        for (int i = 0; i < fileName.Count; i++)
        {
            textArray = FileReader(fileName[i]);
            textArray.Add("\n");
        }
    }

    private void FixedUpdate()
    {
        TextRotation();
    }

    /// <summary>
    /// Событие начала истории
    /// </summary>
    public void MazeStory_Event()
    {
        StartCoroutine(MazeStory());
    }

    /// <summary>
    /// История лабиринта
    /// </summary>
    /// <returns></returns>
    private IEnumerator MazeStory()
    {
        while (true)
        {
            foreach (string s in textArray)
            {
                yield return new WaitForSeconds(Random.Range(3f, 3.5f));
                _text_mesh.text = "";
                yield return new WaitForSeconds(Random.Range(3f, 4f));
                _text_mesh.text = s;
            }
        }
    }

    /// <summary>
    /// Поворот текста в сторону цели
    /// </summary>
    private void TextRotation()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 6, 0);
        text_rot.rotation = Quaternion.LookRotation(-newDir);
    }

    /// <summary>
    /// Заполнение списка из файла
    /// </summary>
    private List<string> FileReader(string fileName)
    {
        string readFromFilePatch = Application.streamingAssetsPath + "/Text/" + fileName + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePatch).ToList();
        return fileLines;
    }
}
