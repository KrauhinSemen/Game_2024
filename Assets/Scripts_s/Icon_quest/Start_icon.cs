using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_icon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("q_icon"))
            {
                PlayerPrefs.SetInt("q_icon", 1);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);
                SceneManager.LoadScene(9);
            }
            else if (PlayerPrefs.GetInt("q_icon") == 3)
            {
                PlayerPrefs.SetInt("q_icon", 4);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);

                DeleteQuestIcon();

                PlayerPrefs.SetInt("Madness", PlayerPrefs.GetInt("Madness") + 10);
                SceneManager.LoadScene(22);
            }
        }
    }

    private void DeleteQuestIcon()
    {
        var items = PlayerPrefs.GetString("items_list").Split("\n");
        var new_items = "";
        for (var i = 0; i < items.Length; i++) if (items[i] != "Икона из Церкви" && items[i] != "") new_items += items[i] + "\n";
        PlayerPrefs.SetString("items_list", new_items);
        // PlayerPrefs.DeleteKey("Записи");
    }
}
