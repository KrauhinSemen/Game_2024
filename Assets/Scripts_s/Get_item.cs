using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
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
                var items = PlayerPrefs.GetString("items_list") + gameObject.name + "\n";
                PlayerPrefs.SetString("items_list", items);
                PlayerPrefs.SetInt(gameObject.name, 1);
            }
            Destroy(gameObject);
        }
    }
}