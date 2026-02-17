using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Type", menuName = ("Create Enemy"))]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    public enum EnemyType
    {
        Melee,
        Ranged,
        Support
    }

    public EnemyType enemyType;

    public float maxHealth;
    public float moveSpeed;
    public float attackDamage;
    public float attackRange;
    public float attackCooldown;
}
