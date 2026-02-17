using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    [Header("Base Stats")]
    public string gunName;
    public float gunDamage;
    public float fireRate;
    public float reloadTime;
    public int magazineSize;
    public int maxAmmo;

    [Header("Presentation")]
    public GameObject gunPrefab;
    public AudioClip fireSound;
    [Range(0f, 1f)] public float fireVolume = 0.5f;
    public Sprite gunIcon;

    [Header("Ability")]
    public bool hasTimedAbility = true;   
    public float abilityDuration = 5f;     
}

