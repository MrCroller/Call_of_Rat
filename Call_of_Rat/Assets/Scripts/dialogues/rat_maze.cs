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
            text_mesh_ratmaze.text = "��� �� � �������� ���������";
            await Task.Delay(3300);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3100);
            text_mesh_ratmaze.text = "������� � ��� �����?";
            await Task.Delay(3500);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3100);
            text_mesh_ratmaze.text = "�������� ���� ������ ����� � �����";
            await Task.Delay(3700);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "� �������� ��� ����� �������������";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "����, ���� �������";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3000);
            text_mesh_ratmaze.text = "����� ��������� ������� ��������?";
            await Task.Delay(3200);
            text_mesh_ratmaze.text = "";
            await Task.Delay(3800);
        }
    }
}
