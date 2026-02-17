using UnityEngine;

[CreateAssetMenu(
    fileName = "New Spread Weapon",
    menuName = "Weapons/Guns/Spread"
)]
public class SpreadWeaponData : WeaponData
{
    public int pelletCount;
    public float spreadAngle;
    public float range;
}

