using UnityEngine;
using System.Collections.Generic;

public class ManagerInput : MonoBehaviour
{
    public static ManagerInput I { get; private set; }
    
    private Dictionary<PlayerNumber, PlayerInput_Base> playerInputs = new();

    void Awake() {
        I = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInputs.Add(PlayerNumber.Mock, GetComponent<PlayerInputMock>());
        playerInputs.Add(PlayerNumber.P1, GetComponent<PlayerInputP1>());
        playerInputs.Add(PlayerNumber.P2, GetComponent<PlayerInputP2>());
        playerInputs.Add(PlayerNumber.P3, GetComponent<PlayerInputP3>());
        playerInputs.Add(PlayerNumber.P4, GetComponent<PlayerInputP4>());

    }
    
    public PlayerInput_Base GetPlayerInput(PlayerNumber playerNumber)
    {
        return playerInputs.GetValueOrDefault(playerNumber);
    }

}
