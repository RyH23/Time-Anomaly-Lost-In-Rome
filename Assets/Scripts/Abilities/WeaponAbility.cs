using UnityEngine;

public class WeaponAbility : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerWeaponController weaponController = other.GetComponent<PlayerWeaponController>();

        if (weaponController == null) return;

        weaponController.EquipWeapon(weaponData);

        Destroy(gameObject);
    }
}
