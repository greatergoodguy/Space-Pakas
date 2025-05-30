using UnityEngine;

public class PlayerInputP4: PlayerInput_Base
{
    public override bool GetKeyForward()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public override bool GetKeyFire()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public override float GetAxisHorizontal()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return -1f;
        }

        return 0f;
    }
}