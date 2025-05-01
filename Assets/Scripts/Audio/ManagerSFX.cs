using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSFX : MonoBehaviour {

    /*
     * 0 - Buzzer
     * 1 - Drum Roll Build Up
     * 2 - Drum Roll Finish
     * 3 - Winner Bell Game Show
     * 4 - Hooray
     * 5 - Button Click 1
     * 6 - Button Click 2
     * 7 - Short Click
     * 8 - Snowball Impact
     * 9 - Snowball Throw
     * 10 - Snowball Make
     * 11 - Coin Received
     * 12 - Snowball Wind Up
     * */

    private static ManagerSFX I;

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
        if (index < 0 || index >= audioClips.Length) {
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