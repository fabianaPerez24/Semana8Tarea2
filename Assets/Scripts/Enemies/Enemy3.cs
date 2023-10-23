using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [SerializeField]
    private int life;

    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;

    public float timer;
    public float maxtimer;

    public float timerBala;
    public float maxtimerBala;

    public GameObject enemybullet;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        if (collision.gameObject.CompareTag("PlayerBullet2"))
        {
            life-=2;
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
        EnemyShoot();
    }
    void Move()
    {
        rb2d.velocity = direction * speed;
    }
    void ChangeDirection()
    {
        timer += Time.deltaTime;
        if (timer >= maxtimer)
        {
            direction *= -1;
            timer = 0;
        }
    }
    void EnemyShoot()
    {
        timerBala += Time.deltaTime;
        if (timerBala >= maxtimerBala)
        {

           
            timerBala = 0;

            Vector2 dir= new Vector2(1,0);
            for (int i = 0; i < 2; i++)
            { 
                GameObject obj = Instantiate(enemybullet);
            obj.transform.position = transform.position;
            obj.GetComponent<Enemy3Bullet>().SetDirection(dir);
                dir *= -1;
            }

        }
    }
}
