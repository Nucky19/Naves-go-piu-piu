using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform bulletSpawnPoint; 

    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Bullet bullet = BulletPool.Instance.GetPlayerBullet(); 
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; 
            bullet.Launch(Vector2.up); 
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.gameObject.CompareTag("EnemyBullet") || collider.gameObject.CompareTag("Enemy"))
    {
        Debug.Log("Pplayer hit by Enemy bullet!"); 
        gameObject.SetActive(false); 
    }
}
}