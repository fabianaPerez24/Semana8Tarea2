using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private int life;

    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;

    public float timer;
    public float maxtimer;

   
        private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            life--;
            if (life < 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            life--;
            if (life < 0)
            {
                Destroy(gameObject);
            }
        }
    }
        void Update()
        {
            Move();
            ChangeDirection();
        }
        void Move()
        {
            rb2d.velocity = direction*speed;
        }
        void ChangeDirection() 
        {
            timer += Time.deltaTime;
            if (timer>=maxtimer)
            {
                direction *= -1;
            timer=0;
            }
        }
    
}
