using UnityEngine;

[CreateAssetMenu(
    fileName = "New Projectile Weapon",
    menuName = "Weapons/Guns/Projectile"
)]
public class ProjectileWeaponData : WeaponData
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
}
