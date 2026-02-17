using UnityEngine;

[CreateAssetMenu(
    fileName = "New Hitscan Weapon",
    menuName = "Weapons/Guns/Hitscan"
)]
public class HitscanWeaponData : WeaponData
{
    public float range;
    public LayerMask hitLayers;
}
