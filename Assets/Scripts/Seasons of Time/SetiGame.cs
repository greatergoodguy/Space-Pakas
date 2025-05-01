using UnityEngine;
using UnityEngine.SceneManagement;

public class SetiGame : Seti_Base {

    public static SetiGame I { get; private set; }

    bool isFinished;
    Seti_Base nextSeason;

    void Awake() {
        I = this;
    }

    public override void Enter() {
        isFinished = false;
        ManagerMusic.Play(0);
        SceneManager.LoadScene("Level 1", LoadSceneMode.Additive);
        
        GameObject player1 = Toolbox.Create("Player 1");
        GameObject player2 = Toolbox.Create("Player 2");
        GameObject cargo   = Toolbox.Create("Cargo");

        HingeJoint2D[] hinges = cargo.GetComponents<HingeJoint2D>();
        if (hinges.Length < 2)
        {
            Debug.LogError("Cargo must have at least 2 HingeJoint2D components.");
            return;
        }

        Rigidbody2D rb1 = player1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = player2.GetComponent<Rigidbody2D>();

        // Position players at the world position of each hinge joint anchor
        Vector3 worldAnchor1 = cargo.transform.TransformPoint(hinges[0].anchor);
        Vector3 worldAnchor2 = cargo.transform.TransformPoint(hinges[1].anchor);

        player1.transform.position = worldAnchor1;
        player2.transform.position = worldAnchor2;

        // Connect each hinge to the corresponding player
        hinges[0].connectedBody = rb1;
        hinges[1].connectedBody = rb2;
    }

    public override void Exit() {
    }

    public override bool IsFinished() {
        return isFinished;
    }

    public override Seti_Base GetNextSeason() {
        return nextSeason;
    }
}