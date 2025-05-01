using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiSetup : Seti_Base {

    public static SetiSetup I;

    void Awake() {
        I = this;
    }

    public override void Enter() {
        MenuStart.I.Hide();
    }

    public override bool IsFinished() {
        return true;
    }

    public override Seti_Base GetNextSeason() {
        return SetiStart.I;
    }
}