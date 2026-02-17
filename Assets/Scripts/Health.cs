using UnityEngine;

public class Health : MonoBehaviour
{
    ArenaManager arenaManager;

    public float maxHealth = 100f;
    private float currentHealth;
    public float currentHealthPercent => currentHealth / maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;

        arenaManager = FindFirstObjectByType<ArenaManager>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0f)
        {
            Die();
            Debug.Log($"{gameObject.name}");
        }
    }

    private void Die()
    {
        if (CompareTag("Player"))
        {
            PlayerDeath();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayerDeath()
    {
        arenaManager.didPlayerDie = true;
    }
}
