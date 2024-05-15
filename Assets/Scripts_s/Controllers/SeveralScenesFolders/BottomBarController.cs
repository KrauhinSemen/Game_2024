using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI textBar;
    public TextMeshProUGUI charNameText;

    private State state = State.COMPLETED;
    private int sentenceIndex = -1;
    private StoryScene currScene;
    private Animator animator;
    private bool isHidden = false;

    private enum State
    {
        COMPLETED, PLAYING
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsCompleted() => state == State.COMPLETED;

    public bool IsLastSentence() => sentenceIndex + 1 == currScene.sentences.Count;

    public void Hide()
    {
        if (!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }
    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
    }

    public void ClearBar()
    {
        textBar.text = "";
        charNameText.text = "";
    }

    public void PlayScene(StoryScene scene, bool isAnimated)
    {
        currScene = scene;
        sentenceIndex = -1;
        PlaySentence(isAnimated);
    }

    public void PlaySentence(bool isAnimated)
    {
        if (isAnimated)
        {
            StartCoroutine(TypeText(currScene.sentences[++sentenceIndex].text));
        }
        else DisplayFullText(currScene.sentences[++sentenceIndex].text);
        charNameText.text = currScene.sentences[sentenceIndex].character.charName;
    }

    private void DisplayFullText(string text)
    {
        textBar.text = text;
        state = State.COMPLETED;
    }

    private IEnumerator TypeText(string text)
    {
        textBar.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            textBar.text += text[wordIndex];
            yield return new WaitForSeconds(0.005f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}