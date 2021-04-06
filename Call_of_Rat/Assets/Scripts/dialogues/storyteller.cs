using System.Collections;
using TMPro;
using UnityEngine;

public class Storyteller : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float dirSpeed;
    [SerializeField] public TextMeshPro text_mesh;

    private void FixedUpdate()
    {
        VissiblePlayer();
    }

    /// <summary>
    /// Реализация события начала истории
    /// </summary>
    public void Startstory_Event()
    {
        StartCoroutine(Start_story());
    }

    /// <summary>
    /// Начальный диалог
    /// </summary>
    private IEnumerator Start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "Привет залетный!";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "";
        text_mesh.text = "Я не знаю как ты сюда попал пацан, но глубоко сочуствую";
        yield return new WaitForSeconds(3.4f);
        text_mesh.text = "";
        text_mesh.text = "Эти каловраты уже и до людей добрались";
        yield return new WaitForSeconds(3.4f);
        text_mesh.text = "";
        text_mesh.text = "Короче, залетный. Я с тобой в благородство играть не буду: выполнишь для меня пару заданий - и мы в расчете";
        yield return new WaitForSeconds(5.0f);
        text_mesh.text = "";
        text_mesh.text = "А теперь нажми на тот темный кирпичик слева от монитора";
    }

    /// <summary>
    /// Реализация события выходв из комнаты
    /// </summary>
    public void Exitstory_Event()
    {
        StopAllCoroutines();
        //StopCoroutine(Start_story());
        StartCoroutine(Exit_start_story());
    }

    /// <summary>
    /// Диалог по выходу из комнаты
    /// </summary>
    private IEnumerator Exit_start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "А ты неплох";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "Для подопытной мыши";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "Значит так. У тебя тут 2 варианта. Пройти скрытно от всех этих культистов, либо раздобыть одно интересное оружие";
        yield return new WaitForSeconds(6.4f);
        text_mesh.text = "Какое спросишь? Они его хранят в дальней комнате. Это дальше по коридору, потом на право. Не заблудись";
        yield return new WaitForSeconds(6.0f);
        text_mesh.text = "";
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
