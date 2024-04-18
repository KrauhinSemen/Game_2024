using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        bool moving = false;
        public float speed1;
        private SpriteRenderer spriteRenderer1;
        private Animator animator1;

        private void Start()
        {
            spriteRenderer1 = GetComponent<SpriteRenderer>();
            animator1 = GetComponent<Animator>();
            if (PlayerPrefs.HasKey("last_x") && PlayerPrefs.HasKey("last_y"))
            {
                gameObject.transform.localPosition = new Vector3(PlayerPrefs.GetFloat("last_x"), PlayerPrefs.GetFloat("last_y"));
                PlayerPrefs.DeleteKey("last_x");
                PlayerPrefs.DeleteKey("last_y");
            }
        }


        private void Update()
        {
            
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                
                dir.x = -1;
                spriteRenderer1.flipX = false;
                animator1.SetInteger("State", 1);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                spriteRenderer1.flipX = true;
                animator1.SetInteger("State", 1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                animator1.SetInteger("State", 2);
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator1.SetInteger("State", 3);
                dir.y = -1;
            }
            if (dir.x !=0 || dir.y != 0)
            {
                moving = true;
            }
            else {
                moving = false;
                animator1.SetInteger("State", 0);
            }
            

            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = speed1 * dir;
        }
    }
}
