using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    public static GameControl S;
    void Awake() { S = this; }

    //VARS_____________________________
    public GameObject flag;
    public bool activeGraphics = false;

    //TRUMP_____________________________
    public bool trumpismActive = false;
    public GameObject mouthOpen;
    public GameObject mouthClosed;
    public ParticleSystem trumpFire;
    public ParticleSystem trumpSmoke;
    
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

    public IEnumerator LaunchTrumpism() {
        //trumpisms
        int rand = Random.Range(0, DataDict.S.trumpisms.Count);
        GameCanvas.S.trumpism.text = DataDict.S.trumpisms[rand];

        //toggle graphics
        float timing = 0f;
        if (!trumpFire.isPlaying) trumpFire.Play();        
        mouthClosed.SetActive(false);
        mouthOpen.SetActive(true);

        while (activeGraphics == true) {
            //smoke
            timing += 0.2f;
            if (timing > 2.5f) if (!trumpSmoke.isPlaying) trumpSmoke.Play();
            yield return new WaitForSeconds(0.2f);
        }
        //stops graphics
        if (!trumpFire.isStopped) trumpFire.Stop();
        if (!trumpSmoke.isStopped) trumpSmoke.Stop();
        mouthClosed.SetActive(true);
        mouthOpen.SetActive(false);
        GameCanvas.S.trumpism.text = "";
    }
}
