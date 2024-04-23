using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private BackgroundController switcher;
    private Animator animator;
    private bool isHiddenChar1 = true;
    private bool isHiddenChar2 = false;

    private void Awake()
    {
        switcher = GetComponent<BackgroundController>();
        animator = GetComponent<Animator>();
    }

    public void Setup(Sprite sprite)
    {
        switcher.SetImage(sprite);
    }

    public void ShowAll()
    {
        animator.SetTrigger("Show");
        isHiddenChar1 = false;
        isHiddenChar2 = false;
    }

    public void HideAll()
    {
        if (!isHiddenChar1 && isHiddenChar2)
        {
            animator.SetTrigger("Hide1");
            isHiddenChar1 = true;
        }
        else if (isHiddenChar1 && !isHiddenChar2){
            animator.SetTrigger("Hide2");
            isHiddenChar2 = true;
        }
        else if (!isHiddenChar1 && !isHiddenChar2)
        {
            animator.SetTrigger("Hide");
            isHiddenChar1 = true;
            isHiddenChar2 = true;
        }
    }
}
