using UnityEngine;
using System.Collections;

public abstract class Seti_Base : MonoBehaviour {

    public virtual void Enter() { }
    public virtual void UpdateSeason() { }
    public virtual void Exit() { }

    public virtual bool IsFinished() { return false; }
    public virtual Seti_Base GetNextSeason() { return SetiMock.I; }
}