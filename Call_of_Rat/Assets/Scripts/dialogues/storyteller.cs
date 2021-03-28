using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class storyteller : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float dirSpeed;
    [SerializeField] public TextMeshPro text_mesh;


    private void FixedUpdate()
    {
        Vector3 dir = _target.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, dirSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    /// <summary>
    /// Начальный диалог
    /// </summary>
    public async void Start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "Привет залетный!";
        await Task.Delay(3000);
        text_mesh.text = "";
        text_mesh.text = "Я не знаю как ты сюда попал пацан, но глубоко сочуствую";
        await Task.Delay(3400);
        text_mesh.text = "";
        text_mesh.text = "Эти каловраты уже и до людей добрались";
        await Task.Delay(3400);
        text_mesh.text = "";
        text_mesh.text = "Короче, залетный. Я с тобой в благородство играть не буду: выполнишь для меня пару заданий - и мы в расчете";
        await Task.Delay(5000);
        text_mesh.text = "";
        text_mesh.text = "А теперь нажми на тот темный кирпичик слева от монитора";
    }

    /// <summary>
    /// Диалог по выходу из комнаты
    /// </summary>
    public async void Exit_start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "А ты неплох";
        await Task.Delay(3000);
        text_mesh.text = "Для подопотной мыши";
        await Task.Delay(3000);
        text_mesh.text = "Значит так. У тебя тут 2 варианта. Пройти скрытно от всех этих культистов, либо раздобыть одно интересное оружие";
        await Task.Delay(6000);
        text_mesh.text = "Какое спросишь? Они его хранят в дальней комнате. Это дальше по коридору, потом на право. Не заблудись";
        await Task.Delay(6000);
        text_mesh.text = "";
    }
}
