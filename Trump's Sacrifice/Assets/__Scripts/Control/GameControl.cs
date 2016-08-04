using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    public static GameControl S;
    void Awake() { S = this; }

    //VARIABLES_____________________________
    public bool trumpismActive = false;

    void Update() {
        if (OneRing.S.gameActive == true) {
            //watch for spacebar press
            if (Input.GetKeyDown("space")) {
                DontPanic();
            }

            //particle system check
            ParticleControl.S.ToggleParticleSystems(OneRing.S.panic);
        }
    }

    public void DontPanic() {
        //reduce panic
        if (OneRing.S.panic != 0) OneRing.S.panic -= 1;
        GameCanvas.S.UpdatePanic(OneRing.S.panic);
    }

    public void LaunchTrumpism() {

    }
}
