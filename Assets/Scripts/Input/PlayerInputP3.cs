using UnityEngine;

public class PlayerInputP3: PlayerInput_Base
{
    public override bool GetKeyForward()
    {
        return Input.GetKey(KeyCode.I);
    }

    public override bool GetKeyFire()
    {
        return Input.GetKeyDown(KeyCode.K);
    }

    public override float GetAxisHorizontal()
    {
        if (Input.GetKey(KeyCode.J))
        {
            return 1f;
        }
        if (Input.GetKey(KeyCode.L))
        {
            return -1f;
        }

        return 0f;
    }
}