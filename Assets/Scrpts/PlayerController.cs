using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;

    private bool salta = false;
    
    public float speed = 10;
    public float upSpeed = 50;
    
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;


    private int Score1 = 0;
    private int Score2 = 0;
    private int Score3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        _animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText1.text = "MODENA TIPO 3: " + Score3;
        ScoreText2.text = "MODENA TIPO 2: " + Score2;
        ScoreText3.text = "MODENA TIPO 1: " + Score1;
        
        
        
        setIdleAnimation();
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            setRunAnimation();
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            setRunAnimation();
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0 ,rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && salta)
        {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * upSpeed;
            salta = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        salta = true;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Gold")
        {
            IncrementarPuntajeGold();
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.tag == "Silver")
        {
            IncrementarPuntajeSilver();
            Destroy(other.gameObject);
        }
        else
        {
            IncrementarPuntajeBronze();
            Destroy(other.gameObject);
        }


    }


    private void setJumpAnimation()
    {
        _animator.SetInteger("Estado",2);
    }

    private void setRunAnimation()
    {
        _animator.SetInteger("Estado", value:1);
    }

    private void setIdleAnimation()
    {
        _animator.SetInteger("Estado", value:0);
    }
    
    public void IncrementarPuntajeGold()
    {
        Score1 += 30;
    }
    public void IncrementarPuntajeSilver()
    {
        Score2 += 20;
    }
    public void IncrementarPuntajeBronze()
    {
        Score3 += 10;
    }
}
