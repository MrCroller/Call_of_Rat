using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rat_maze : MonoBehaviour
{
    [SerializeField] public TextMeshPro text_mesh_ratmaze;
    [SerializeField] public Transform text_rot;
    /// <summary>
    /// Цель для поворота
    /// </summary>
    [SerializeField] private Transform _target;

    /// <summary>
    /// Начальный текст при встрече
    /// </summary>
    private List<string> startStory_text;

    private void Awake()
    {
        startStory_text = new List<string>()
        {
            "Как же я ненавижу лабиринты",
            "Сколько я уже здесь?",
            "Наверное дома сейчас тепло и уютно",
            "А говорили мне стать программистом",
            "Блин, сыра хочется",
            "Может прогрызть туннель напрямую?",
        };

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
    /// Поворот текста в сторону цели
    /// </summary>
    private void TextRotation()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 6, 0);
        text_rot.rotation = Quaternion.LookRotation(-newDir);
    }
}
