using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed;
    private Rigidbody2D rb2d;
    [SerializeField]
    public GameObject bulletPrefab;

    private float shootTimer;
    private float shootDelayTime;

    public int life;

    // Update is called once per frame
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
        if (collision.gameObject.CompareTag("Enemybullet"))
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(horizontal, vertical);
 
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
            obj.transform.position = transform.position;
            shootTimer = 0;
        }
    }
}
