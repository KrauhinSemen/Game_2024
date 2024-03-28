using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_script : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1600, 1200, true);
    }

    public void Play(int scene_number)
    {
        SceneManager.LoadScene(scene_number);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
