using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class hero_script : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    private Rigidbody2D rb;
    [SerializeField]private int speed_hero = 2;
    private CircleCollider2D cc;

    [SerializeField] bool bonk_check = false, bonk_roflan = false, bonk_sit = false;

    private Animator anim;
    
    
    int hp = 3;

    void Start()
    {

        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        


    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        /*   if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A))
           {
               if (bonk_sit == true)
               {
                   cc.enabled = false;
               }
               else { bonk_sit = false; }
           } */
        if (Input.GetKey(KeyCode.Escape)){ 
        }
            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
        {

            if (bonk_sit)
            {
                anim.SetBool("check_sit_run", true);
            }
            else
            {
                anim.SetBool("check_run", true);
            }



            rb.MovePosition(rb.position + Vector2.right * moveX * Time.deltaTime * speed_hero);
        }
        else
        {
            if (bonk_sit)
            {
                anim.SetBool("check_sit_run", false);
            }
            else
            {
                anim.SetBool("check_run", false);
            }
        }

        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector2.up * moveY * Time.deltaTime * speed_hero);
        }




        //      rb.velocity = new Vector2(moveInput * speed_kek, rb.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "enemy")
        {
            GameObject.Find("Hero").transform.position = new Vector3(-9,3,0);
            hp--;
            switch (hp)
            {
                case 2:
                     GameObject.Find("hp3").active = false;
                    
                    break;
                case 1:
                    GameObject.Find("hp2").active = false;
                    break;
                case 0:
                    Application.LoadLevel("menu");
                    break;
            }
            
        }

        if (collision.gameObject.tag == "bonk" & bonk_check == true)
        {
            Debug.Log("Bonk");
            cc.enabled = false;
            Debug.Log(cc.enabled);
        }
        if (collision.gameObject.tag == "end")
        {
            Application.LoadLevel("Next_level");
        }
    }
        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.A))
            {

                rb.transform.localScale = new Vector3(-4f, 4, 0f);



            }
            else


            if (Input.GetKey(KeyCode.D))
            {
                rb.transform.localScale = new Vector3(4f, 4, 0f);
            }

            //______________________________________________


            if (Input.GetKeyDown(KeyCode.F))
            {
                bonk_sit = true;
                cc.enabled = false;
                anim.SetBool("check_sit", true);
                anim.SetBool("check_up", false);
                bonk_roflan = true;

            }
            if (Input.GetKeyDown(KeyCode.R) | Input.GetKeyDown(KeyCode.W) & bonk_roflan == true)
            {
                anim.SetBool("check_up", true);
                bonk_check = true;
                anim.SetBool("check_sit", false);
                cc.enabled = true;
            }

            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) & bonk_check == true)
            {
                bonk_check = false;
            }
        }
    }


