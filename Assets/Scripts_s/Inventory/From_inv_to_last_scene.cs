using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class From_inv_to_last_scene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.I)) SceneManager.LoadScene(PlayerPrefs.GetInt("last_scene"));
    }
}
