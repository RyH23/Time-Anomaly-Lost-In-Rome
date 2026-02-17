using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private Transform player;

    float moveSpeed = 3;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        MoveTorwardsPlayer();
    }

    void MoveTorwardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        transform.LookAt(player);
    }
}
