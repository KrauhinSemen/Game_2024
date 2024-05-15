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

    public void New_game()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Madness", 50);
        PlayerPrefs.SetString("items_list", "");
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        if (PlayerPrefs.HasKey("last_scene")) SceneManager.LoadScene(PlayerPrefs.GetInt("last_scene"));
    }

    public void Game_info(Canvas canvas)
    {
        canvas.sortingOrder = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back(Canvas canvas)
    {
        canvas.sortingOrder = -1;
    }
}
