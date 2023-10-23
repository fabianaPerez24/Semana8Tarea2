using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    [SerializeField]
    private int life;

    public float timerBala;
    public float maxtimerBala;

    public GameObject enemybullet;


    Vector2 InitialPosition;
    private void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position= Vector2.zero;
        position.x = Mathf.Cos(Time.time);
        position.y = Mathf.Sin(Time.time);
        transform.position= InitialPosition+position;

        EnemyShoot();
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
    void EnemyShoot()
    {
        timerBala += Time.deltaTime;
        if (timerBala >= maxtimerBala)
        {


            timerBala = 0;

            Vector2 dir = new Vector2(1, 1);
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(enemybullet);
                obj.transform.position = transform.position;
                obj.GetComponent<Enemy3Bullet>().SetDirection(dir);
                dir.x -= 1;
                //dir.y *= -1;
            }


        }
    }

}
