using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleControl : MonoBehaviour {
    public static ParticleControl S;
    void Awake() { S = this; }

    //VARIABLES_______________________________________
    public List<ParticleSystem> stageOne;

    public void InitializeParticleSystem() {
      
    }

    public void ToggleParticleSystems(int panic) {
        if (panic >= 76) {
            
        }
        else if (panic >= 51 && panic <= 75) {
           
        }
        else if (panic >= 26 && panic <= 50) {
            for (int i = 0; i < stageOne.Count; i++) {
                if (!stageOne[i].isPlaying) stageOne[i].Play();
            }                 
        }
        else if (panic <= 25) {
            for (int i = 0; i < stageOne.Count; i++) {
                if (!stageOne[i].isStopped) stageOne[i].Stop();
            }
        }
    }

}
