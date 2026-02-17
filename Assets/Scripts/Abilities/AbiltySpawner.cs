using Unity.VisualScripting;
using UnityEngine;

public class AbiltySpawner : MonoBehaviour
{
    ArenaManager arenaManager;

    [SerializeField] GameObject[] spawnAbilities;
    [SerializeField] GameObject[] spawnPoints;
    public float spawnTimer;
    public float coolDown;

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
                SpawnAbility();
                spawnTimer = coolDown;
            }
        }
    }

    void SpawnAbility()
    {
        Instantiate(
            spawnAbilities[Random.Range(0, spawnAbilities.Length)],
            spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position,
            transform.rotation
        );
    }
}
