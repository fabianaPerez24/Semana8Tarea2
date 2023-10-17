using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private int life;
    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
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
        void Update()
        {
            Move();
        }
        void Move()
        {
            rb2d.velocity = direction*speed;
        }
    }
}
