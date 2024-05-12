using UnityEngine;
using UnityEngine.UI;

public class ButtonCPKIO : MonoBehaviour
{
    public bool isOpen = false; // ���������� Bool, �������������� ��������
    public Animator animator; // ��������� Animation, ������� ����� ��������� ���������

    void Start()
    {
        // �������� ��������� Animation
        animator = GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {
        isOpen = !isOpen; // ����������� �������� ����������
        animator.SetBool("Open", isOpen); // ��������� ��������
    }
}