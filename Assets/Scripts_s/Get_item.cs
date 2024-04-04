using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var items = PlayerPrefs.GetString("items_list") + gameObject.name + "\n";
            PlayerPrefs.SetString("items_list", items);
            Destroy(gameObject);
        }
    }
}