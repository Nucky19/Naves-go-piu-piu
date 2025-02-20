using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada generación de enemigos
    public float spawnRangeX = 8f; // Rango en el eje X para la generación de enemigos
    public float spawnY = 6f; // Posición Y desde donde aparecerán los enemigos

    void Start()
    {
        // Llama a la función SpawnEnemy repetidamente
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Obtiene un enemigo del pool
        Enemy enemy = EnemyPool.Instance.GetEnemy();
        if (enemy != null)
        {
            // Genera una posición aleatoria en el eje X dentro del rango especificado
            float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            enemy.gameObject.SetActive(true); // Activa el enemigo
        }
    }
}