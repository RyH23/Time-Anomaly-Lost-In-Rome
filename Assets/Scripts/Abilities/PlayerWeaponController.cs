using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponSocket;

    private WeaponData currentWeapon;
    private GameObject currentWeaponInstance;

    private float abilityTimer = 0f;
    private bool abilityActive = false;

    public WeaponData CurrentWeapon => currentWeapon;
    public Transform WeaponSocket => weaponSocket;

    public void EquipWeapon(WeaponData newWeapon)
    {
        // Destroy old weapon if exists
        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
        }

        // Set current weapon data
        currentWeapon = newWeapon;

        // Instantiate the weapon prefab
        Quaternion weaponRotation = Quaternion.Euler(0, -90, 0);
        currentWeaponInstance = Instantiate(
            newWeapon.gunPrefab,
            weaponSocket.position,
            weaponSocket.rotation * weaponRotation,
            weaponSocket
        );

        // Ability logic
        if (newWeapon.hasTimedAbility)
        {
            abilityTimer = Time.time + newWeapon.abilityDuration;
            abilityActive = true;
        }
        else
        {
            abilityActive = false;
        }
    }

    private void Update()
    {
        ActivatedAbility();
    }

    private void RemoveWeapon()
    {
        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
            currentWeaponInstance = null;
        }

        currentWeapon = null;
    }

    private void ActivatedAbility()
    {
        if (abilityActive)
        {
            float secondsPassed = Time.time - (abilityTimer - currentWeapon.abilityDuration);
            float remaining = abilityTimer - Time.time;

            //Debug.Log($"Ability elapsed: {secondsPassed:F2}s, remaining: {remaining:F2}s");

            if (Time.time >= abilityTimer)
            {
                abilityActive = false;
                RemoveWeapon();
            }
        }
    }
}
