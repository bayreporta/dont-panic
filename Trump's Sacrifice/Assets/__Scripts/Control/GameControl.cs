using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public static GameControl S;
    void Awake() { S = this; }

    //VARS_____________________________
    public GameObject flag;
    public bool activeGraphics = false;

    //TRUMP_____________________________
    public bool trumpismActive = false;
	public List<string> usedTrumpisms;
    public GameObject mouthOpen;
    public GameObject mouthClosed;
    public ParticleSystem trumpFire;
    public ParticleSystem trumpSmoke;
    
    void Update() {
        if (OneRing.S.gameActive == true) {

			//game over due to panic
			if (OneRing.S.panic >= 100) {
				OneRing.S.gameActive = false;
				ParticleControl.S.ToggleParticleSystems (OneRing.S.panic);
				OneRing.S.GameOver (0);
			} else {
				//watch for spacebar press
				if (Input.GetKeyDown ("space")) {
					DontPanic ();
				}

				//particle system check
				ParticleControl.S.ToggleParticleSystems (OneRing.S.panic);
			}

            
        }
    }

    public void DontPanic() {
        //reduce panic
		OneRing.S.timesDontPanic += 1;
		OneRing.S.panic = 90f;
        //if (OneRing.S.panic != 0) OneRing.S.panic -= 0.5f;
        GameCanvas.S.UpdatePanic(OneRing.S.panic);
    }

	string WhichTrumpism(List<string> t){
		bool winner = false;
		string val = "";

		//check to see if all trumpisms have been used and reset
		if (t.Count == usedTrumpisms.Count) {
			usedTrumpisms = new List<string> ();
		}

		//keep looping for a winner until you find one
		while (winner == false) {
			int rand = Random.Range (0, t.Count);
			val = t [rand];

			//check to see if trumpism has aready been used
			if (usedTrumpisms.Contains (val)) {
				continue;
			} else {
				usedTrumpisms.Add (val);
				winner = true;
			}
		}
		return val;
	}	

    public IEnumerator LaunchTrumpism() {
        //trumpisms
		GameCanvas.S.trumpism.text = WhichTrumpism(DataDict.S.trumpisms);

        //toggle graphics
        float timing = 0f;
		GameCanvas.S.warning.gameObject.SetActive (true);
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
		GameCanvas.S.warning.gameObject.SetActive (false);
        if (!trumpFire.isStopped) trumpFire.Stop();
        if (!trumpSmoke.isStopped) trumpSmoke.Stop();
        mouthClosed.SetActive(true);
        mouthOpen.SetActive(false);
        GameCanvas.S.trumpism.text = "";
    }
}
