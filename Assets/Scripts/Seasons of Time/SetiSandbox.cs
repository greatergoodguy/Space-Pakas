using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetiSandbox : Seti_Base {

    public static SetiSandbox I { get; private set; }

    bool _isFinished;
    Seti_Base _nextSeason;
    
    bool _isPaused;
    
    MenuPause _menuPause;
    
    GameObject _cargo, _player1, _player2, _player3, _player4;

    void Awake() {
        I = this;
    }

    public override void Enter() {
        _isFinished = false;
        _isPaused = false;
        _menuPause = MenuPause.I;
        
        _menuPause.onResumePressed = Unpause;
        _menuPause.onQuitPressed = Quit;
        
        ManagerMusic.Play(0);
        SceneManager.LoadScene("Sandbox", LoadSceneMode.Additive);

        _cargo = Toolbox.Create("CargoPod");
        
        _player1 = Toolbox.CreatePlayer(PlayerNumber.P1);
        _player2 = Toolbox.CreatePlayer(PlayerNumber.P2);
        _player3 = Toolbox.CreatePlayer(PlayerNumber.P3);
        _player4 = Toolbox.CreatePlayer(PlayerNumber.P4);
        
        _cargo.GetComponent<Cargo>().AttachPlayers(new List<GameObject> { _player1, _player2, _player3, _player4 });
    }
    
    public override void UpdateSeason() {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            Pause();
        }
    }
    
    public override void Exit()
    {
        if (_menuPause)
        {
            _menuPause.onResumePressed = null;
            _menuPause.onQuitPressed = null;
        }
        
        ManagerMusic.Stop(0);
        if (SceneManager.GetSceneByName("Sandbox").isLoaded)
            SceneManager.UnloadSceneAsync("Sandbox");
        
        if (_cargo) Destroy(_cargo);
        if (_player1) Destroy(_player1);
        if (_player2) Destroy(_player2);
        if (_player3) Destroy(_player3);
        if (_player4) Destroy(_player4);
    }

    public override bool IsFinished() {
        return _isFinished;
    }

    public override Seti_Base GetNextSeason() {
        return _nextSeason;
    }
    
    private void Pause() {
        Toolbox.Log("Game Paused");
        _isPaused = true;
        Time.timeScale = 0f;
        _menuPause.Show();
    }
    
    private void Unpause() {
        Toolbox.Log("Game Unpaused");
        _isPaused = false;
        Time.timeScale = 1f;
        _menuPause.Hide();
    }
    
    private void Quit() {
        _isPaused = false;
        Time.timeScale = 1f;
        _menuPause.Hide();
        _nextSeason = SetiStart.I;
        _isFinished = true;
    }
    
    public void AttachPlayers(GameObject[] players)
    {
        
    }
}