using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private BackgroundController switcher;
    private Animator animator;
    private RectTransform rect;

    private void Awake()
    {
        switcher = GetComponent<BackgroundController>();
        animator = GetComponent<Animator>();
        rect = GetComponent<RectTransform>();
    }
    public void Setup(Sprite sprite)
    {
        switcher.SetImage(sprite);
    }

    public void Show(Vector2 coords)
    {
        animator.SetTrigger("Show");
        rect.localPosition = coords;
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
    }

    public void Move(Vector2 coords, float speed)
    {
        StartCoroutine(MoveCoroutine(coords, speed));
    }

    private IEnumerator MoveCoroutine(Vector2 coords, float speed)
    {
        while (rect.localPosition.x != coords.x || rect.localPosition.y != coords.y)
        {
            rect.localPosition = Vector2.MoveTowards(rect.localPosition, coords,
                Time.deltaTime * 1000f * speed);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
