using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2f; 
    public float spawnRangeX = 8f; 
    public float spawnY = 6f; 

    void Start()
    {
  
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {

        Enemy enemy = EnemyPool.Instance.GetEnemy();
        if (enemy != null)
        {
           
            float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            enemy.gameObject.SetActive(true); 
        }
    }
}