using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public ChangerScene currScene;
    public BottomBarController bar;
    public BackgroundController backgroundController;
    public ChooseController chooseController;
    public SpriteController sprites;

    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currScene is StoryScene)
        {
            StoryScene storyScene = currScene as StoryScene;
            bar.PlayScene(storyScene, true);
            backgroundController.SetImage(storyScene.background);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClicks(true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HandleClicks(false);
        }
    }

    private void HandleClicks(bool isAnimated)
    {
        if (state == State.IDLE && bar.IsCompleted())
        {
            if (bar.IsLastSentence())
            {
                StoryScene story = currScene as StoryScene;
                if (story.IsLastScene)
                {
                    SceneManager.LoadScene("Main_menu");
                }
                else
                {
                    PlayScene(story.nextScene);
                }
            }
            else
            {
                bar.PlaySentence(isAnimated);
            }
        }
    }

    public void PlayScene(ChangerScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(ChangerScene scene)
    {
        state = State.ANIMATE;
        currScene = scene;
        bar.Hide();
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SwitchImage(storyScene.background);
            sprites.ShowAll();
            yield return new WaitForSeconds(1f);
            bar.ClearBar();
            bar.Show();
            yield return new WaitForSeconds(1f);
            bar.PlayScene(storyScene, true);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}
