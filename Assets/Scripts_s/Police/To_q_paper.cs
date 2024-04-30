using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPaper : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteKey("q_paper");
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
