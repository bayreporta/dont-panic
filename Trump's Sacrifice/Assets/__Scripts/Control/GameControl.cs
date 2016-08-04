using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    public static GameControl S;
    void Awake() { S = this; }

    //VARIABLES_____________________________
    public bool trumpismActive = false;

    public void DontPanic() {
        //reduce panic
        if (OneRing.S.panic != 0) OneRing.S.panic -= 1;
        GameCanvas.S.UpdatePanic(OneRing.S.panic);
    }

    public void LaunchTrumpism() {

    }
}
