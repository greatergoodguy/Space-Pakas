using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputManager inputManager;
    private ShipController shipController;

    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        shipController = GetComponent<ShipController>();
    }

    public void HandleMovement(bool moveForward, float rotationInput, bool isShooting)
    {
        shipController.HandleMovement(moveForward, rotationInput, isShooting);
    }
}