using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMusic : MonoBehaviour {
    /*
     * 0 - Lunadyas - Amidst Blue - 10 In Fear And Fury
     * 1 -
     * 2 -
     * 3 -
     * 4 -
     * 5 -
     *
     *
     * */

    public static ManagerMusic I;

    AudioSource[] audioClips;

    void Awake() {
        I = this;
        audioClips = GetComponents<AudioSource>();
    }
    
    public static void Play(int index) {
        if (I == null) { return; }
        I._Play(index);
    }

    public static void Stop(int index) {
        if (I == null) { return; }
        I._Stop(index);
    }
    
    private void _Play(int index) {
        if (index < 0 || index >= audioClips.Length)
        {
            Toolbox.Log("Play(int index): invalid index");
            return;
        }
        audioClips[index].Play();
    }

    private void _Stop(int index) {
        if (index < 0 || index >= audioClips.Length) {
            Toolbox.Log("Stop(int index): invalid index");
            return;
        }

        audioClips[index].Stop();
    }
}