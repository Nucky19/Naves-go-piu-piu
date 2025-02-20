using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public Transform bulletSpawnPoint; // Punto desde donde se disparan las balas
    public float shootInterval = 2f; // Intervalo de tiempo entre disparos
    private float nextShootTime = 0f; // Tiempo para el próximo disparo

    void Update()
    {
        Move(); // Mover el enemigo

        // Verificar si es tiempo de disparar
        if (Time.time >= nextShootTime)
        {
            Shoot(); // Disparar
            nextShootTime = Time.time + shootInterval; // Actualizar el tiempo para el próximo disparo
        }
    }

    void Move()
    {
        // Mover el enemigo hacia abajo
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        // Desactivar el enemigo si sale de la cámara
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        // Obtener una bala del pool de enemigos
        Bullet bullet = BulletPool.Instance.GetEnemyBullet();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; // Posición de la bala
            bullet.Launch(Vector2.down); // Lanzar la bala hacia abajo
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si colisiona con una bala del jugador
        if(collision.CompareTag("EnemyBullet")){
            return;
        }
        if (collision.CompareTag("PlayerBullet"))
        {
            Debug.Log("Enemy hit by player bullet!"); // Mensaje de depuración
            gameObject.SetActive(false); // Desactivar el enemigo
            collision.gameObject.SetActive(false); // Desactivar la bala del jugador
        }
    }
}