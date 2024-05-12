using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPaper : MonoBehaviour
{
    private void Start()
    {
        // ��� ������ ������
        /*
        PlayerPrefs.DeleteKey("q_paper");
        PlayerPrefs.DeleteKey("items_list"); // ��� ������ ������
        PlayerPrefs.DeleteKey("������");
        */

        /*
        PlayerPrefs.SetInt("q_paper", 1); // ������� �������
        
        var items = PlayerPrefs.GetString("items_list").Split("\n");
        var new_items = "";
        for (var i = 0; i < items.Length; i++) if (items[i] != "������") new_items += items[i] + "\n";
        PlayerPrefs.SetString("items_list", new_items);
        PlayerPrefs.DeleteKey("������");
        PlayerPrefs.DeleteKey("items_list");
        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("q_paper"))
            {
                PlayerPrefs.SetInt("q_paper", 1);
                PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);

                var player = collision.gameObject;
                PlayerPrefs.SetFloat("last_x", player.transform.position.x);
                PlayerPrefs.SetFloat("last_y", player.transform.position.y);
                SceneManager.LoadScene(4);
            }
        }
    }
}
