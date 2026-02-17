using UnityEngine;

public class UPDown : MonoBehaviour
{
    [SerializeField] float maxHeight = 0.5f;
    [SerializeField] float frequency = 1.0f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

        frequency = Random.Range(2f, 6);
    }

    private void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * maxHeight;
        transform.position = startPos + Vector3.up * yOffset;
    }
}
