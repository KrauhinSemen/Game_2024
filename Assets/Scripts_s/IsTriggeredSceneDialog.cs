using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsTriggeredSceneDialog : IsTriggered
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }
    }
}
