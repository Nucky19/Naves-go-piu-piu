using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject playerBulletPrefab; 
    public GameObject enemyBulletPrefab;
    public int playerPoolSize = 20; 
    public int enemyPoolSize = 20;

    private List<Bullet> playerBullets; 
    private List<Bullet> enemyBullets; 

    void Awake()
    {
        Instance = this; 
        playerBullets = new List<Bullet>();
        enemyBullets = new List<Bullet>();

        
        for (int i = 0; i < playerPoolSize; i++)
        {
            Bullet bullet = Instantiate(playerBulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false); 
            playerBullets.Add(bullet);
        }

        
        for (int i = 0; i < enemyPoolSize; i++)
        {
            Bullet bullet = Instantiate(enemyBulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            enemyBullets.Add(bullet); 
        }
    }

  
    public Bullet GetPlayerBullet()
    {
        foreach (Bullet bullet in playerBullets)
        {
            if (!bullet.gameObject.activeInHierarchy) 
            {
                return bullet; 
            }
        }
        return null; 
    }

    
    public Bullet GetEnemyBullet()
    {
        foreach (Bullet bullet in enemyBullets)
        {
            if (!bullet.gameObject.activeInHierarchy) 
            {
                return bullet; 
            }
        }
        return null; 
    }
}