using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb2d;
    [SerializeField]
    private Vector2 direction;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        
        rb2d.velocity = direction * speed;
    }
}

