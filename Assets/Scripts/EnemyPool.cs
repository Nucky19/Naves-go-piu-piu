using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance; // Instancia singleton
    public GameObject enemyPrefab; // Prefab del enemigo
    public int poolSize = 10; // Tamaño del pool

    private List<Enemy> enemies; // Lista para almacenar los enemigos

    void Awake()
    {
        Instance = this; // Asignar la instancia
        enemies = new List<Enemy>();

        // Inicializar el pool de enemigos
        for (int i = 0; i < poolSize; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemy.gameObject.SetActive(false); // Desactivar el enemigo al instanciar
            enemies.Add(enemy); // Agregar el enemigo al pool
        }
    }

    // Método para obtener un enemigo del pool
    public Enemy GetEnemy()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.gameObject.activeInHierarchy) // Verificar si el enemigo está inactivo
            {
                return enemy; // Retornar el enemigo inactivo
            }
        }
        return null; // Si no hay enemigos disponibles
    }
}