using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5000;
    public float damage = 10f;

    private int timeLeft = 5;

    public GameObject shooter;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, timeLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == shooter) return;

        Health playerHealth = other.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            //Debug.Log($"Arrow hit {other.name} for {damage} damage");
        }

        
        Destroy(gameObject);
    }
}
