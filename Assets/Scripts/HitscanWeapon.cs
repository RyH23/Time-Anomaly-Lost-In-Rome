using UnityEngine;

public class HitscanWeapon : MonoBehaviour
{
    [SerializeField] private PlayerWeaponController weaponController;
    ArenaManager arenaManager;

    private float nextFireTime = 0f;

    private void Start()
    {
        arenaManager = FindFirstObjectByType<ArenaManager>();
    }

    private void Update()
    {
        if (weaponController.CurrentWeapon == null) return;

        if (arenaManager.didPlayerDie == false)
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                Shoot();
            }
        }        
    }

    private void Shoot()
    {
        var weaponData = weaponController.CurrentWeapon as HitscanWeaponData;
        if (weaponData == null) return;

        nextFireTime = Time.time + 1f / weaponData.fireRate;

        Vector3 origin = weaponController.WeaponSocket.position;
        Vector3 direction = weaponController.WeaponSocket.forward * weaponData.range;

        Debug.DrawLine(origin, origin + direction, Color.red, 1f);

        // Play firing sound
        if (weaponData.fireSound != null)
        {
            AudioSource.PlayClipAtPoint(weaponData.fireSound, weaponController.WeaponSocket.position, weaponData.fireVolume);
        }

        // Perform hitscan raycast
        Ray ray = new Ray(origin, weaponController.WeaponSocket.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, weaponData.range))
        {
            Debug.Log($"Hit {hit.collider.name} for {weaponData.gunDamage} damage");

            var targetHealth = hit.collider.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(weaponData.gunDamage);
            }
        }
    }
}

