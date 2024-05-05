using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsTriggered : MonoBehaviour
{
    public Animator anim;
    public GameObject frame;
    public GameObject[] otherFrames;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("OurTrigger");
            frame.SetActive(true);
            foreach (GameObject frame in otherFrames)
            {
                frame.SetActive(false);
            }
         
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
          if (Input.GetKey(KeyCode.E))
          {
              SceneManager.LoadScene(6);
          }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            anim.SetTrigger("OurTrigger");
        }
    }
}
