using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class rat_maze : MonoBehaviour
{
    [SerializeField] public TextMeshPro text_mesh_ratmaze;
    [SerializeField] public Transform text_rot;
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        Vector3 dir = _target.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 6, 0);

        text_rot.rotation = Quaternion.LookRotation(-newDir);
    }

    public async void MazeStory()
    {
        while (true)
        {
            text_mesh_ratmaze.text = "Как же я ненавижу лабиринты";
            await Task.Delay(3300);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3100);
            text_mesh_ratmaze.text = "Сколько я уже здесь?";
            await Task.Delay(3500);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3100);
            text_mesh_ratmaze.text = "Наверное дома сейчас тепло и уютно";
            await Task.Delay(3700);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "А говорили мне стать программистом";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "Блин, сыра хочется";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "Может прогрызть туннель напрямую?";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3800);
        }
    }
}
