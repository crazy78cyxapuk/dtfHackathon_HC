using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    //private Collider2D[] floorCol; //коллайдеры пола
    private float speed = 3f;
    private float jump = 10;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Vector2 dir;
    private bool death=false;
    public static int countJump;//кол-во прыжков
    //private bool addSpeed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = Vector2.right;
        countJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetMouseButtonDown(0) ||  (Input.touchCount > 0)) && isGrounded)
        //{
        //    rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        //    createFloor.upPlayer = true;
        //}
        transform.Translate(dir * speed * Time.deltaTime);
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            btnJump();
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount == 1 && isGrounded)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                btnJump();
            }
        }
#endif

        if (transform.position.x>2.9 || transform.position.x < -2.9)
        {
            death = true;
        }
        if (death)
        {
            SceneManager.LoadScene(0);
        }

        ////ускорение игрока
        //if (countJump % 10 == 0)
        //{
        //    addSpeed = true;
        //}
        //if (addSpeed)
        //{
        //    addSpeed = false;
        //    speed += 0.3f;
        //}

    }

    public void btnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            createFloor.upPlayer = true;
            countJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
        }
        if (collision.gameObject.tag == "LeftSide")
        {
            dir = Vector2.right;
        }
        if (collision.gameObject.tag == "RightSide")
        {
            dir = Vector2.left;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            
        }
    }
}
