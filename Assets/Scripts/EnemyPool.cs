using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance; 
    public GameObject enemyPrefab; 
    public int poolSize = 10; 

    private List<Enemy> enemies; 

    void Awake()
    {
        Instance = this; 
        enemies = new List<Enemy>();

       
        for (int i = 0; i < poolSize; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemy.gameObject.SetActive(false); 
            enemies.Add(enemy); 
        }
    }

   
    public Enemy GetEnemy()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.gameObject.activeInHierarchy) 
            {
                return enemy; 
            }
        }
        return null; 
    }
}