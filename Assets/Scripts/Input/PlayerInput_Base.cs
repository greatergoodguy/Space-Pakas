using UnityEngine;

public class PlayerInput_Base : MonoBehaviour
{
    public virtual bool GetKeyForward()
    {
        return false; 
    }
    
    public virtual bool GetKeyFire()
    {
        return false; 
    }
    
    public virtual float GetAxisHorizontal()
    {
        return 0; 
    }
}
