using UnityEngine;
using System.Collections.Generic;

public class Cargo : MonoBehaviour
{
    private List<HingeJoint2D> hingeJoints;

    void Awake()
    {
        hingeJoints = new List<HingeJoint2D>(GetComponents<HingeJoint2D>());   
    }
    
    void Start()
    {
    }

    public void AttachPlayers(List<GameObject> players)
    {
        int count = Mathf.Min(players.Count, hingeJoints.Count);
        
        for (int i = 0; i < count; i++)
        {
            Vector3 worldAnchor = transform.TransformPoint(hingeJoints[i].anchor);
            players[i].transform.position = worldAnchor;
            hingeJoints[i].connectedBody = players[i].GetComponent<Rigidbody2D>();
        }
    }

}
