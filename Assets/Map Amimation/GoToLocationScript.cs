using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLocationScript : MonoBehaviour
{
    public int SceneNumber = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void SetSceneNumber(int x) { 
        SceneNumber = x;
    }
}
