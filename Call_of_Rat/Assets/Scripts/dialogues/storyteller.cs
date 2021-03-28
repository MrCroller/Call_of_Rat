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
    /// ��������� ������
    /// </summary>
    public async void Start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "������ ��������!";
        await Task.Delay(3000);
        text_mesh.text = "";
        text_mesh.text = "� �� ���� ��� �� ���� ����� �����, �� ������� ���������";
        await Task.Delay(3400);
        text_mesh.text = "";
        text_mesh.text = "��� ��������� ��� � �� ����� ���������";
        await Task.Delay(3400);
        text_mesh.text = "";
        text_mesh.text = "������, ��������. � � ����� � ������������ ������ �� ����: ��������� ��� ���� ���� ������� - � �� � �������";
        await Task.Delay(5000);
        text_mesh.text = "";
        text_mesh.text = "� ������ ����� �� ��� ������ �������� ����� �� ��������";
    }

    /// <summary>
    /// ������ �� ������ �� �������
    /// </summary>
    public async void Exit_start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "� �� ������";
        await Task.Delay(3000);
        text_mesh.text = "��� ���������� ����";
        await Task.Delay(3000);
        text_mesh.text = "������ ���. � ���� ��� 2 ��������. ������ ������� �� ���� ���� ����������, ���� ��������� ���� ���������� ������";
        await Task.Delay(6000);
        text_mesh.text = "����� ��������? ��� ��� ������ � ������� �������. ��� ������ �� ��������, ����� �� �����. �� ���������";
        await Task.Delay(6000);
        text_mesh.text = "";
    }
}
