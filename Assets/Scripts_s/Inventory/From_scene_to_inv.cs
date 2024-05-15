using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class From_scene_to_inv : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetFloat("last_x", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("last_y", gameObject.transform.position.y);
            PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);
            if (Input.GetKey(KeyCode.I)) SceneManager.LoadScene(3);
            else SceneManager.LoadScene(0);
        }
    }
}
