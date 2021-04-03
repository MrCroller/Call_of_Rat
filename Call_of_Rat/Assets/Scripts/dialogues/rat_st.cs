using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Rat_st : MonoBehaviour
{
    // ����� �� �����
    [SerializeField] public TextMeshPro text_mesh_st;

    // ����� ��������� 1
    [SerializeField] public TextMeshPro text_mesh_listener1;

    // ����� ��������� 2
    [SerializeField] public TextMeshPro text_mesh_listener2;

    // ����� ��������� 3
    [SerializeField] public TextMeshPro text_mesh_listener3;

    /// <summary>
    /// �����
    /// </summary>
    public async void Pasta()
    {
        text_mesh_st.text = "������, �� ����� ��������� ��� ����";
        await Task.Delay(3000);
        text_mesh_st.text = "�� �������, ��������, ��� ��� �����";
        await Task.Delay(3000);
        text_mesh_st.text = "��� �� ��";
        await Task.Delay(1500);
        text_mesh_st.text = "��� �� �������� � ���� �� ������ ���������";
        await Task.Delay(3000);
        text_mesh_st.text = "���� ����� �� �����";
        await Task.Delay(2000);
        text_mesh_st.text = "��������, ����� �� ��� ����� ������";
        await Task.Delay(3000);
        text_mesh_st.text = "����� ������� ��� ���� � �������, ��� ��� ����������";
        await Task.Delay(3000);
        text_mesh_st.text = "� ������ �������, ��� ������ ���������� ������ �������������� �������, �� ���� ����� ������������ �������� - ����";
        await Task.Delay(5000);
        text_mesh_st.text = "��������� ������ �� ������";
        await Task.Delay(2400);
        text_mesh_st.text = null;
        await Task.Delay(3000);
        Joke1();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void Joke1()
    {
        text_mesh_listener1.text = "������� ������� ��������, ������� ��� � ���� � ����������:";
        await Task.Delay(3000);
        text_mesh_listener1.text = "- ������, �����, ��������� ����?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "�������:";
        await Task.Delay(1000);
        text_mesh_listener1.text = "- ���.";
        await Task.Delay(1000);
        text_mesh_listener1.text = "� ����� ������� � ���� � ����������:";
        await Task.Delay(2400);
        text_mesh_listener1.text = "- ������, �����, ��������� ����?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "�������:";
        await Task.Delay(1000);
        text_mesh_listener1.text = "- �� ����, ����!";
        await Task.Delay(2000);
        text_mesh_listener1.text = "� ��� ����� ������� :";
        await Task.Delay(1800);
        text_mesh_listener1.text = "- ������, �����, ��������� ����?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "�� ������� �� ��������:";
        await Task.Delay(2000);
        text_mesh_listener1.text = "- ����, �� ���� ������ �������, ���� ������ ��������� ! ���� ������ - ������� �� �����!";
        await Task.Delay(3700);
        text_mesh_listener1.text = null;
        await Task.Delay(3000);
        React1();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void Joke2()
    {
        text_mesh_listener3.text = "���������� �������, ���� ������:";
        await Task.Delay(2300);
        text_mesh_listener3.text = "- ���������!!!! �����!!! ��� �����??!! �� ��� ����������!!!! �������!!! ...";
        await Task.Delay(3000);
        text_mesh_listener3.text = "����� ����� ��� ������ �� �����";
        await Task.Delay(1700);
        text_mesh_listener3.text = "�� �������������, � ��� �������� ����� ��������, �����������";
        await Task.Delay(3200);
        text_mesh_listener3.text = "��������:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "�� ���� �����?!";
        await Task.Delay(2000);
        text_mesh_listener3.text = "�������:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "- �� ��� ����...  ";
        await Task.Delay(2000);
        text_mesh_listener3.text = "���������� �...";
        await Task.Delay(2000);
        text_mesh_listener3.text = "����� ����� ������� ���...";
        await Task.Delay(2000);
        text_mesh_listener3.text = "��������:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "- �� � �������, ����� �����?";
        await Task.Delay(3700);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        React2();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void Joke3()
    {
        text_mesh_listener3.text = "���� ������� �� ����";
        await Task.Delay(2600);
        text_mesh_listener3.text = "����� ��������� ����� ������, ������� ������� ����������";
        await Task.Delay(3200);
        text_mesh_listener3.text = "- �� �� �������, ���������? - ����������";
        await Task.Delay(2440);
        text_mesh_listener3.text = "- ��� ���� �������, ������ ��������� �������, �������� �������...";
        await Task.Delay(3120);
        text_mesh_listener3.text = "- � ������ � ���� ���� ���?";
        await Task.Delay(2470);
        text_mesh_listener3.text = "- ����! - ��������� ���������";
        await Task.Delay(2370);
        text_mesh_listener3.text = "�������, ������� ������� � ���������:";
        await Task.Delay(2630);
        text_mesh_listener3.text = "- ����! ����! ���������! ������! ����!!!";
        await Task.Delay(3680);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        React3();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void React1()
    {
        text_mesh_listener3.text = "�� �� ���, ������� ��� �������, ���� � �������";
        await Task.Delay(2400);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        Joke2();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void React2()
    {
        text_mesh_listener1.text = "�� �� �����";
        await Task.Delay(2400);
        text_mesh_listener1.text = null;
        await Task.Delay(3000);
        Joke3();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    public async void React3()
    {
        text_mesh_listener2.text = "��� �� ������ ��";
        await Task.Delay(2400);
        text_mesh_listener2.text = null;
        await Task.Delay(3000);
        Joke1();
    }
}
