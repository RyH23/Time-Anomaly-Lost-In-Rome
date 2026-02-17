using UnityEngine;

public class S_FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2;
    float _cameraVerticalRotation = 0;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Collect Mouse Input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the Camera around its local X axis
        _cameraVerticalRotation -= inputY;
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90, 90);
        transform.localEulerAngles = Vector3.right * _cameraVerticalRotation;

        // Rotate the Camera around its local Y axis
        player.Rotate(Vector3.up * inputX);
    }

}
