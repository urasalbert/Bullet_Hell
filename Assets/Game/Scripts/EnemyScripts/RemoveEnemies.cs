using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemies : MonoBehaviour
{
    // Script to delete all enemies when boss spawns
    private List<GameObject> enemies;
    private EnemyHealthManager[] allEnemies;

    private void Update()
    {
        if (GameTimer.Instance.minutes == 10)
        {
            AddAllEnemiesToTheList();
            RemoveAllEnemies();
        }
    }

    void RemoveAllEnemies()
    {
        List<GameObject> enemiesToRemove = new List<GameObject>();

        // Collect the enemies to be removed
        foreach (GameObject enemy in enemies)
        {
            enemiesToRemove.Add(enemy);
        }

        // Remove them from the original list
        foreach (GameObject enemy in enemiesToRemove)
        {
            Destroy(enemy); // Optionally, you can destroy the GameObjects if needed
            enemies.Remove(enemy);
        }
    }

    void AddAllEnemiesToTheList()
    {
        allEnemies = FindObjectsOfType<EnemyHealthManager>();

        enemies = new List<GameObject>();

        foreach (EnemyHealthManager enemy in allEnemies) // Add all enemies except boss
        {
            if (enemy.gameObject.tag != "Boss")
            {
                enemies.Add(enemy.gameObject);
            }
        }
    }
}
