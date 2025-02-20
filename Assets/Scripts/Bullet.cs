using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 direction;

    // Método para lanzar la bala en una dirección específica
    public void Launch(Vector2 dir)
    {
        direction = dir;
        gameObject.SetActive(true); // Activar la bala
    }

    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(direction * speed * Time.deltaTime);
        
        // Desactivar la bala si sale de la cámara
        if (transform.position.y > Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // Verificar si colisiona con un enemigo
    //     if (collision.CompareTag("Enemy"))
    //     {
    //         Debug.Log("Bullet hit an enemy!"); // Mensaje de depuración
    //         gameObject.SetActive(false); // Desactivar la bala
    //         collision.gameObject.SetActive(false); // Desactivar el enemigo
    //     }
    // }
}