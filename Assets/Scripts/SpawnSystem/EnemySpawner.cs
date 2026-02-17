using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawnTiers spawnTiers;
    ArenaManager arenaManager;

    [SerializeField] float spawnTimer = 5;
    [SerializeField] float coolDown;

    private void Start()
    {
        arenaManager = FindFirstObjectByType<ArenaManager>();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (arenaManager.didPlayerDie == false)
        {
            if (spawnTimer <= 0)
            {
                SpawnEnemy();
                spawnTimer = coolDown;
            }
        }
    }

    void SpawnEnemy()
    {

        GameObject[] enemies = spawnTiers.enemies;

        Instantiate(
            enemies[Random.Range(0, enemies.Length)], 
            transform.position, 
            transform.rotation
        );
    }
}
