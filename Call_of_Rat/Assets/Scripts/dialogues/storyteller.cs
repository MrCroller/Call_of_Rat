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
    /// ���������� ������� ������ �������
    /// </summary>
    public void Startstory_Event()
    {
        StartCoroutine(Start_story());
    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    private IEnumerator Start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "������ ��������!";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "";
        text_mesh.text = "� �� ���� ��� �� ���� ����� �����, �� ������� ���������";
        yield return new WaitForSeconds(3.4f);
        text_mesh.text = "";
        text_mesh.text = "��� ��������� ��� � �� ����� ���������";
        yield return new WaitForSeconds(3.4f);
        text_mesh.text = "";
        text_mesh.text = "������, ��������. � � ����� � ������������ ������ �� ����: ��������� ��� ���� ���� ������� - � �� � �������";
        yield return new WaitForSeconds(5.0f);
        text_mesh.text = "";
        text_mesh.text = "� ������ ����� �� ��� ������ �������� ����� �� ��������";
    }

    /// <summary>
    /// ���������� ������� ������ �� �������
    /// </summary>
    public void Exitstory_Event()
    {
        StopAllCoroutines();
        //StopCoroutine(Start_story());
        StartCoroutine(Exit_start_story());
    }

    /// <summary>
    /// ������ �� ������ �� �������
    /// </summary>
    private IEnumerator Exit_start_story()
    {
        text_mesh.text = "";
        text_mesh.text = "� �� ������";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "��� ���������� ����";
        yield return new WaitForSeconds(3.0f);
        text_mesh.text = "������ ���. � ���� ��� 2 ��������. ������ ������� �� ���� ���� ����������, ���� ��������� ���� ���������� ������";
        yield return new WaitForSeconds(6.4f);
        text_mesh.text = "����� ��������? ��� ��� ������ � ������� �������. ��� ������ �� ��������, ����� �� �����. �� ���������";
        yield return new WaitForSeconds(6.0f);
        text_mesh.text = "";
    }

    /// <summary>
    /// ������� �� ������
    /// </summary>
    private void VissiblePlayer()
    {
        Vector3 dir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, dirSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
