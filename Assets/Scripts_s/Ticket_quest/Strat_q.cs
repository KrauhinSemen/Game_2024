using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Strat_q : MonoBehaviour
{
    public Animator anim;
    public GameObject frame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!PlayerPrefs.HasKey("q_ticket") || PlayerPrefs.GetInt("q_ticket") == 2))
        {
            anim.SetTrigger("OurTrigger");
            frame.SetActive(true);
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
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
                    SceneManager.LoadScene(21);
                }
            }
        }
    }
    private void DeleteQuestTicket()
    {
        var items = PlayerPrefs.GetString("items_list").Split("\n");
        var new_items = "";
        for (var i = 0; i < items.Length; i++) if (items[i] != "Пропуск Работяги" && items[i] != "") new_items += items[i] + "\n";
        PlayerPrefs.SetString("items_list", new_items);
        // PlayerPrefs.DeleteKey("Записи");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!PlayerPrefs.HasKey("q_ticket")|| PlayerPrefs.GetInt("q_ticket") == 2))
        {
            anim.SetTrigger("OurTrigger");
        }
    }
}
