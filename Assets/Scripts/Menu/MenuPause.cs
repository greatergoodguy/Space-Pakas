using System;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static MenuPause I;
    
    GameObject _goContainer;
    
    public Action onResumePressed;
    public Action onQuitPressed;
    void Awake()
    {
        I = this;
        _goContainer = transform.Find("Container").gameObject;
    }

    void Start() {
        Hide();
    }

    public void Show() {
        _goContainer.SetActive(true);
    }

    public void Hide() {
        _goContainer.SetActive(false);
    }
    
    // ====================
    // UI Callbacks
    // ====================
    public void OnButtonResume() {
        ManagerSFX.Play(5);
        onResumePressed?.Invoke(); 
    }

    public void OnButtonQuit() {
        ManagerSFX.Play(5);
        onQuitPressed?.Invoke(); 
    }
}