using UnityEngine;
using UnityEngine.UI;

public class ButtonCPKIO : MonoBehaviour
{
    public bool isOpen = false; // Переменная Bool, контролирующая анимацию
    public Animator animator; // Компонент Animation, который будет управлять анимацией

    void Start()
    {
        // Получаем компонент Animation
        animator = GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {
        isOpen = !isOpen; // Переключаем значение переменной
        animator.SetBool("Open", isOpen); // Запускаем анимацию
    }
}