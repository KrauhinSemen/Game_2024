using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class From_scene_to_inv : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(3);
        }
    }
}
