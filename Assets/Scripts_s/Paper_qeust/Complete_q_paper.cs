using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete_q_paper : MonoBehaviour
{
    public Animator anim;
    public GameObject frame;
    private void Start()
    {
        // PlayerPrefs.SetInt("q_paper", 2);  // Для квеста с наличием предмета
        //PlayerPrefs.DeleteAll();
        //  PlayerPrefs.SetInt("Madness", 50);
        //PlayerPrefs.SetString("items_list", "");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&PlayerPrefs.HasKey("q_paper") && PlayerPrefs.GetInt("q_paper") == 2)
        {
            anim.SetTrigger("OurTrigger");
            frame.SetActive(true);
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (PlayerPrefs.HasKey("q_paper") && PlayerPrefs.GetInt("q_paper") == 2) //С Кустовой
            {
                PlayerPrefs.SetInt("q_paper", 3);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);

                DeleteQuestRecord();

                if (gameObject.name == "Кустова")
                {
                    PlayerPrefs.SetInt("Madness", PlayerPrefs.GetInt("Madness") + 30);
                    SceneManager.LoadScene(5);
                }
                else
                {
                    PlayerPrefs.SetInt("Madness", PlayerPrefs.GetInt("Madness") - 30);
                    SceneManager.LoadScene(7);
                }
            }
        }
    }

    private void DeleteQuestRecord()
    {
        var items = PlayerPrefs.GetString("items_list").Split("\n");
        var new_items = "";
        for (var i = 0; i < items.Length; i++) if (items[i] != "Записи" && items[i] != "") new_items += items[i] + "\n";
        PlayerPrefs.SetString("items_list", new_items);
        // PlayerPrefs.DeleteKey("Записи");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerPrefs.HasKey("q_paper") && PlayerPrefs.GetInt("q_paper") == 2)
        {
            anim.SetTrigger("OurTrigger");
        }
    }
}

