using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Strat_q : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("q_ticket"))
            {
                PlayerPrefs.SetInt("q_ticket", 1);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);
                SceneManager.LoadScene(8);
            }
            else if (PlayerPrefs.GetInt("q_ticket") == 2)
            {
                PlayerPrefs.SetInt("q_ticket", 3);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);
                DeleteQuestTicket();
                PlayerPrefs.SetInt("Madness", PlayerPrefs.GetInt("Madness") - 10);
                SceneManager.LoadScene(8); // Здесь одна и та же сцена!
            }
        }
    }
    private void DeleteQuestTicket()
    {
        var items = PlayerPrefs.GetString("items_list").Split("\n");
        var new_items = "";
        for (var i = 0; i <= items.Length; i++) if (items[i] != "Пропуск Работяги") new_items += items[i] + "\n";
        PlayerPrefs.SetString("items_list", new_items);
        // PlayerPrefs.DeleteKey("Записи");
    }
}
