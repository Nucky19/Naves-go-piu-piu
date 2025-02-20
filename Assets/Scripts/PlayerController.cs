using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform bulletSpawnPoint; // Punto desde donde se disparan las balas

    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0)) // Disparar al hacer clic
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
        Bullet bullet = BulletPool.Instance.GetPlayerBullet(); // Obtener una bala del pool del jugador
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; // Posición de la bala
            bullet.Launch(Vector2.up); // Lanzar la bala hacia arriba
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.gameObject.CompareTag("EnemyBullet") || collider.gameObject.CompareTag("Enemy"))
    {
        Debug.Log("Pplayer hit by Enemy bullet!"); // Mensaje de depuración
        gameObject.SetActive(false); // Desactivar el enemigo
    }
}
}