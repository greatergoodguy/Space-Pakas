using UnityEngine;

public class SetiStart : Seti_Base {

    public static SetiStart I { get; private set; }

    MenuStart menuStart;

    bool isFinished;
    Seti_Base nextSeason;

    void Awake() {
        I = this;
    }

    public override void Enter() {
        menuStart = MenuStart.I;
        menuStart.Show();

        isFinished = false;
    }

    public override void Exit() {
        menuStart.Hide();
    }

    public override bool IsFinished() {
        return isFinished;
    }

    public override Seti_Base GetNextSeason() {
        return nextSeason;
    }
    
    // ====================
    // UI Callbacks
    // ====================
    public void OnButtonPlay() {
        isFinished = true;
        nextSeason = SetiGame.I;
        ManagerSFX.Play(5);
    }

    public void OnButtonChallenges() {
        isFinished = true;
        nextSeason = SetiMock.I;
        ManagerSFX.Play(5);
    }
    
    
    public void OnButtonSandbox() {
        isFinished = true;
        nextSeason = SetiSandbox.I;
        ManagerSFX.Play(5);
    }

    public void OnButtonQuit() {
        ManagerSFX.Play(5);
        Application.Quit();
    }
}