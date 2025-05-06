using UnityEngine;

public class PlayerInputP1 : PlayerInput_Base
{
    public override bool GetKeyForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    public override bool GetKeyFire()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public override float GetAxisHorizontal()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            return -1f;
        }

        return 0f;
    }
}