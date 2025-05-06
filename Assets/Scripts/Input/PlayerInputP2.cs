using UnityEngine;

public class PlayerInputP2: PlayerInput_Base
{
    public override bool GetKeyForward()
    {
        return Input.GetKey(KeyCode.T);
    }

    public override bool GetKeyFire()
    {
        return Input.GetKeyDown(KeyCode.G);
    }

    public override float GetAxisHorizontal()
    {
        if (Input.GetKey(KeyCode.F))
        {
            return 1f;
        }
        if (Input.GetKey(KeyCode.H))
        {
            return -1f;
        }

        return 0f;
    }
}