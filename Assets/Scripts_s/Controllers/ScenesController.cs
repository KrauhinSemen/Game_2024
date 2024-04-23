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
            bar.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (state == State.IDLE && bar.IsCompleted())
            {
                if (bar.IsLastSentence())
                {
                    StoryScene story = currScene as StoryScene;
                    if (story.IsLastScene)
                    {
                        LoadNextScene();
                    }
                    else
                    {
                        PlayScene(story.nextScene);
                    }
                }
                else
                {
                    bar.PlaySentence();
                }
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
            yield return new WaitForSeconds(1f);
            bar.ClearBar();
            bar.Show();
            yield return new WaitForSeconds(1f);
            bar.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}
