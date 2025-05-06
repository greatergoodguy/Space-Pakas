using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Constants I;
    
    public float speed = 0.01f;
    public float rotationSpeed = 180f;
    public float recoilForce = 1f;
    public float maxSpeed = 8f;

    void Awake() {
        I = this;
    }
}
