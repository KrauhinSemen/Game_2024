using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneChangerController : MonoBehaviour
{
    public ChangerScene currScene;
    public BottomBarController bottomBar;
    private State state = State.IDLE;
    public ChooseController chooseController;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currScene is StoryScene)
        {
            StoryScene storyScene = currScene as StoryScene;
            bottomBar.PlayScene(storyScene);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {

            if (state == State.IDLE && bottomBar.IsCompleted())
            {

                if (bottomBar.IsLastSentence())
                {
                    PlayScene((currScene as StoryScene).nextScene);
                }
                else
                {
                    bottomBar.PlaySentence();
                }
            }
        } 
    }

    public void PlayScene(ChangerScene scene) => StartCoroutine(SwitchScene(scene));

    private IEnumerator SwitchScene(ChangerScene scene)
    {
        state = State.ANIMATE;
        currScene = scene;
        bottomBar.Hide();
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            yield return new WaitForSeconds(1f);
            bottomBar.ClearBar();
            bottomBar.Show();
            yield return new WaitForSeconds(1f);
            bottomBar.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}
