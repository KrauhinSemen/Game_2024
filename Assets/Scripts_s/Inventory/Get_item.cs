using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GetItem : MonoBehaviour
{
    void Start()
    {
        // Строчки для удаления конкретного предмета и очистки инвентаря
        //PlayerPrefs.DeleteKey(gameObject.name);
        //PlayerPrefs.DeleteKey("items_list");
        if (PlayerPrefs.GetInt(gameObject.name) == 1) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.GetInt(gameObject.name) != 1)
            {
                if (gameObject.name == "Записи")
                {
                    if (PlayerPrefs.GetInt("q_paper") == 1)
                    {
                        PlayerPrefs.SetInt("q_paper", 2);
                        SetInfo();
                    }
                }
                else if (gameObject.name == "Пропуск Работяги")
                {
                    if (PlayerPrefs.GetInt("q_ticket") == 1)
                    {
                        PlayerPrefs.SetInt("q_ticket", 2);
                        SetInfo();
                    }
                }
                else if (gameObject.name == "Икона из Церкви")
                {
                    if (PlayerPrefs.GetInt("q_icon") == 2)
                    {
                        PlayerPrefs.SetInt("q_icon", 3);
                        SetInfo();
                    }
                }
            }
        }
    }

    private void SetInfo()
    {
        var items = PlayerPrefs.GetString("items_list") + gameObject.name + "\n";
        PlayerPrefs.SetString("items_list", items);
        PlayerPrefs.SetInt(gameObject.name, 1);
        Destroy(gameObject);
    }
}