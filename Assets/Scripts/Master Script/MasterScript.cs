using UnityEngine;

public class MasterScript : MonoBehaviour {
    public static MasterScript I { get; private set; }

    public bool audioEnabled = true;

    public Seti_Base seasonOfTime;

    [SerializeField]
    public bool debug = false;

    public bool IsProduction { get { return !debug; } }

    void Awake() {
        I = this;
    }

    void Start() {
        if (!audioEnabled) {
            AudioListener.volume = 0;
        }

        Toolbox.Log("Start()");
        seasonOfTime.Enter();
        Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
    }

    void Update() {
        seasonOfTime.UpdateSeason();

        if (seasonOfTime.IsFinished()) {
            seasonOfTime.Exit();
            Toolbox.Log(seasonOfTime.GetType().Name + ": Exit");
            seasonOfTime = seasonOfTime.GetNextSeason();
            Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
            seasonOfTime.Enter();
        }
    }
}
