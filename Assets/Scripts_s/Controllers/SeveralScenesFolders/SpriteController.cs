using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private BackgroundController switcher;
    private Animator animator;
    private bool[] isHidden = new bool[5] { true, false, false, false, false};

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
        for (int i = 0; i < isHidden.Length; i++)
        {
            if (isHidden[i])
            {
                animator.SetTrigger("Show" + (i + 1));
                isHidden[i] = false;
                if (i < isHidden.Length - 1)
                    isHidden[i + 1] = true;
                break;
            }
        }
    }
}
