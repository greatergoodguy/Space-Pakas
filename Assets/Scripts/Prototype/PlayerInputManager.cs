using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public string playerId; // Unique identifier for each player
    private PlayerController playerController;

    void Start()
    {
        // Get the PlayerController associated with this input manager
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Get input based on playerId, e.g., Player 1 (WASD) or Player 2 (Arrow keys)
        if (playerId == "Player1")
        {
            HandleInput(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space);
        }
        else if (playerId == "Player2")
        {
            HandleInput(KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.Return);
        }
    }

    void HandleInput(KeyCode up, KeyCode left, KeyCode down, KeyCode right, KeyCode shoot)
    {
        // Forward movement
        bool moveForward = Input.GetKey(up);
        // Rotation movement (horizontal axis)
        float rotation = 0f;
        if (Input.GetKey(left)) rotation = 1f;
        else if (Input.GetKey(right)) rotation = -1f;

        // Shooting
        bool isShooting = Input.GetKeyDown(shoot);

        // Send the inputs to PlayerController
        playerController.HandleMovement(moveForward, rotation, isShooting);
    }
}