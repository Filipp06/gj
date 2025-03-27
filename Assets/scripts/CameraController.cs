using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Camera modes
    public enum CameraMode
    {
        ThirdPerson,
        TopDown
    }

    // Camera configuration
    [SerializeField] private CameraMode currentMode = CameraMode.ThirdPerson;
    [SerializeField] private Transform target; // Character to follow

    // Third-person camera settings
    [SerializeField] private Vector3 thirdPersonOffset = new Vector3(0, 2, -5);
    [SerializeField] private float thirdPersonAngle = 20f;

    // Top-down camera settings
    [SerializeField] private Vector3 topDownOffset = new Vector3(0, 10, 0);
    [SerializeField] private float topDownAngle = 90f;

    // Camera component
    private Camera mainCamera;

    void Start()
    {
        // If no target is assigned, try to use the parent object
        if (target == null)
            target = transform;

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found in the scene!");
            enabled = false;
        }
    }

    void LateUpdate()
    {
        // Position the camera based on the current mode
        switch (currentMode)
        {
            case CameraMode.ThirdPerson:
                UpdateThirdPersonCamera();
                break;
            case CameraMode.TopDown:
                UpdateTopDownCamera();
                break;
        }
    }

    void UpdateThirdPersonCamera()
    {
        // Calculate camera position with offset
        Vector3 desiredPosition = target.position + target.TransformDirection(thirdPersonOffset);
        mainCamera.transform.position = desiredPosition;

        // Calculate camera rotation
        Quaternion desiredRotation = Quaternion.Euler(thirdPersonAngle, target.eulerAngles.y, 0);
        mainCamera.transform.rotation = desiredRotation;
    }

    void UpdateTopDownCamera()
    {
        // Position camera directly above the target
        Vector3 desiredPosition = target.position + topDownOffset;
        mainCamera.transform.position = desiredPosition;

        // Look straight down
        mainCamera.transform.rotation = Quaternion.Euler(topDownAngle, 0, 0);
    }

    // Input System method to switch camera modes
    public void OnCameraSwitch(InputValue value)
    {
        // Cycle between available modes
        currentMode = (currentMode == CameraMode.ThirdPerson)
            ? CameraMode.TopDown
            : CameraMode.ThirdPerson;

        // Optional: Log the current camera mode
        Debug.Log($"Switched to {currentMode} Camera Mode");
    }
}