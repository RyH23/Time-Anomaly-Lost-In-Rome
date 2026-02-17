using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform firePoint;

    private Transform player;

    float currentHealth;
    float attackCooldown = 8;
    float nextAttackTime;

    float rangedAttackCooldown = 2;
    float nextRangedAttackTime;

    ArenaManager arenaManager;

    private void Awake()
    {
        if (enemyData != null)
        {
            currentHealth = enemyData.maxHealth;
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        arenaManager = FindFirstObjectByType<ArenaManager>();
    }

    private void Update()
    {
        if (arenaManager.didPlayerDie == false)
        {
                switch (enemyData.enemyType)
                {
                    case EnemyData.EnemyType.Melee:
                        ChasePlayer();
                        break;
                    case EnemyData.EnemyType.Ranged:
                        RangedAttack();
                        break;
                    case EnemyData.EnemyType.Support:

                        break;
                }
        }
    }

    void ChasePlayer()
    {
        float step = enemyData.moveSpeed * Time.deltaTime;

        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, targetPosition);

        transform.LookAt(targetPosition);

        if (distance > enemyData.attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void AttackPlayer()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(enemyData.attackDamage);
            Debug.Log($"{enemyData.enemyName} attacked player for {enemyData.attackDamage} damage");
        }
    }

    void RangedAttack()
    {
        float step = enemyData.moveSpeed * Time.deltaTime;

        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, targetPosition);

        transform.LookAt(targetPosition);

        if (distance > enemyData.attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            if (Time.time >= nextRangedAttackTime)
            {
                ShootArrow();
                nextRangedAttackTime = Time.time + rangedAttackCooldown;
            }
        }
    }


    void ShootArrow()
    {

        if (arrowPrefab == null || firePoint == null) return;

        GameObject arrowInstance = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Arrow arrowScript = arrowInstance.GetComponent<Arrow>();

        if (arrowScript != null)
        {
            arrowScript.damage = enemyData.attackDamage;
            arrowScript.shooter = this.gameObject;
        }
    }
}
