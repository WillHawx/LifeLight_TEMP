using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharControl : MonoBehaviour
{
    public int jumpflag;
    public float tempy;
    public float maxjump;
    public int speed;
    public int jumpforce;
    public int direction;
    public int ismoving;
    public int airborn;
    public static int secondj;
    public static int isgrnd;
    public static int faceright;
    public static int airbornS;
    Animator anim;
    Rigidbody2D mybody;
    private void Start()
    {
        name = "player";
        direction = 1;
        faceright = 1;
        isgrnd = 1;
        secondj = 2;
        ismoving = 0;
        anim = GetComponentInChildren<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        airborn = airbornS = 0;
    }
    private void FixedUpdate()
    {
    }
    void Update()
    {
        if (mybody.velocity.y != 0) airborn = 1;
        else airborn = 0;
        airbornS = airborn;
        jumpflag = isgrnd;
        //anim.SetFloat("velocity", ismoving);
        // anim.SetFloat("airborn", airborn);
        // anim.SetInteger("heavy", heavy);
        if (mybody.velocity.x == 0) ismoving = 0;
        else ismoving = 1;
        if (mybody.velocity.y < -0.1)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, mybody.velocity.y * 1.15f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (direction == 1)
            {
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.5f);
            }
            else transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (direction == -1)
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            direction = 1;
            faceright = 1;
            mybody.AddForce(Vector2.right * direction * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (direction == 1)
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            direction = -1;
            faceright = 0;
            mybody.AddForce(Vector2.right * direction * speed);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (secondj > 0)
            {
                secondj--;
                tempy = transform.position.y;
                maxjump = tempy + 2f;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isgrnd == 1)
            {
                // Debug.Log("up arrow");
                if (transform.position.y < maxjump)
                {
                    //Debug.Log("up arrow+1");
                    mybody.AddForce(Vector2.up * jumpforce);
                }
                else
                {
                    isgrnd = 0;
                    mybody.AddForce(Vector2.down * jumpforce * 4);
                }
            }
        }
    }
}
