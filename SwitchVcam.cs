using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVcam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private int priorityBoostAmount = 10;
    
    [SerializeField]
    private Canvas thirdPersonCanvas;
    
    [SerializeField]
    private Canvas aimCanvas;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];

        // Ensure the aim canvas is disabled at the start
        aimCanvas.enabled = false;
    }

    private void OnEnable()
    {
        aimAction.performed += StartAim;
        aimAction.canceled += CancelAim;
    }

    private void OnDisable()
    {
        aimAction.performed -= StartAim;
        aimAction.canceled -= CancelAim;
    }

    private void StartAim(InputAction.CallbackContext context) 
    {
        virtualCamera.Priority += priorityBoostAmount;  // Boost the camera priority
        aimCanvas.enabled = true;  // Enable the aim canvas when aiming
        thirdPersonCanvas.enabled = false;  // Disable the third-person canvas
    }

    private void CancelAim(InputAction.CallbackContext context) 
    {
        virtualCamera.Priority -= priorityBoostAmount;  // Restore the camera priority
        aimCanvas.enabled = false;  // Disable the aim canvas when not aiming
        thirdPersonCanvas.enabled = true;  // Re-enable the third-person canvas
    }
}
