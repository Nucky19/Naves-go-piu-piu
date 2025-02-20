using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance; // Instancia singleton
    public GameObject playerBulletPrefab; // Prefab de la bala del jugador
    public GameObject enemyBulletPrefab; // Prefab de la bala del enemigo
    public int playerPoolSize = 20; // Tamaño del pool de balas del jugador
    public int enemyPoolSize = 20; // Tamaño del pool de balas del enemigo

    private List<Bullet> playerBullets; // Lista para almacenar las balas del jugador
    private List<Bullet> enemyBullets; // Lista para almacenar las balas del enemigo

    void Awake()
    {
        Instance = this; // Asignar la instancia
        playerBullets = new List<Bullet>();
        enemyBullets = new List<Bullet>();

        // Inicializar el pool de balas del jugador
        for (int i = 0; i < playerPoolSize; i++)
        {
            Bullet bullet = Instantiate(playerBulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false); // Desactivar la bala al instanciar
            playerBullets.Add(bullet); // Agregar la bala al pool
        }

        // Inicializar el pool de balas del enemigo
        for (int i = 0; i < enemyPoolSize; i++)
        {
            Bullet bullet = Instantiate(enemyBulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false); // Desactivar la bala al instanciar
            enemyBullets.Add(bullet); // Agregar la bala al pool
        }
    }

    // Método para obtener una bala del pool del jugador
    public Bullet GetPlayerBullet()
    {
        foreach (Bullet bullet in playerBullets)
        {
            if (!bullet.gameObject.activeInHierarchy) // Verificar si la bala está inactiva
            {
                return bullet; // Retornar la bala inactiva
            }
        }
        return null; // Si no hay balas disponibles
    }

    // Método para obtener una bala del pool del enemigo
    public Bullet GetEnemyBullet()
    {
        foreach (Bullet bullet in enemyBullets)
        {
            if (!bullet.gameObject.activeInHierarchy) // Verificar si la bala está inactiva
            {
                return bullet; // Retornar la bala inactiva
            }
        }
        return null; // Si no hay balas disponibles
    }
}