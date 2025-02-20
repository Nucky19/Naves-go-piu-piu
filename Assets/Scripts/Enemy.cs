using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; 
    public Transform bulletSpawnPoint; 
    public float shootInterval = 2f; 
    private float nextShootTime = 0f; 

    void Update()
    {
        Move(); 

       
        if (Time.time >= nextShootTime)
        {
            Shoot(); 
            nextShootTime = Time.time + shootInterval; 
        }
    }

    void Move()
    {
    
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
     
        Bullet bullet = BulletPool.Instance.GetEnemyBullet();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; 
            bullet.Launch(Vector2.down); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("EnemyBullet")){
            return;
        }
        if (collision.CompareTag("PlayerBullet"))
        {
            Debug.Log("Enemy hit by player bullet!"); 
            gameObject.SetActive(false); 
            collision.gameObject.SetActive(false); 
        }
    }
}