using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private Rigidbody2D rb2d;
    [SerializeField]
    public GameObject bulletPrefab;
    private  Vector2 direction;

    private float shootTimer;
    private float shootDelayTime;

    public int life;

    // Update is called once per frame

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        timer();
        Shoot();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            if(life < 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            life--;
            if (life < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Move()
    {
        direction.x  = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(direction.x, direction.y)*speed;
 
   }
    void timer()
    {
        shootTimer += Time.deltaTime;
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootDelayTime)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = new Vector2(direction.x,direction.y);
            shootTimer = 0;
        }
    }
}
