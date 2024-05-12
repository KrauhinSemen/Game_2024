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
        if (SceneNumber == -1)
        {
            //goto restoran
            int madness = PlayerPrefs.GetInt("Madness");
            if (madness <= 49)
            {
                SceneManager.LoadScene(SceneNumber);
            }
            else if (madness == 50)
            {
                SceneManager.LoadScene(SceneNumber);
            }
            else if (madness >= 51 && madness <= 80)
            {
                SceneManager.LoadScene(SceneNumber);
            }
            else
            {
                SceneManager.LoadScene(SceneNumber);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneNumber);
        }
    }
    public void SetSceneNumber(int x) { 
        SceneNumber = x;
    }
}
