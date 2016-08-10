using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleControl : MonoBehaviour {
    public static ParticleControl S;
    void Awake() { S = this; }

    //VARIABLES_______________________________________
    public List<ParticleSystem> stageOne;
    public List<ParticleSystem> stageTwo;
    public List<ParticleSystem> stageThree;

    public void InitializeParticleSystem() {
      
    }

    public void ToggleParticleSystems(float panic) {
        if (panic >= 75) {
            //start stage 3
            for (int i = 0; i < stageTwo.Count; i++) {
                if (!stageThree[i].isPlaying) stageThree[i].Play();
            }

            //stop stage 2
            for (int i = 0; i < stageTwo.Count; i++) {
                if (!stageTwo[i].isPlaying) stageTwo[i].Play();
            }
        }
        else if (panic >= 50 && panic < 75) {
            //play stage 2
            for (int i = 0; i < stageTwo.Count; i++) {
                if (!stageTwo[i].isPlaying) stageTwo[i].Play();
            }

            //stop stage 3
            for (int i = 0; i < stageTwo.Count; i++) {
                if (!stageThree[i].isStopped) stageThree[i].Stop();
            }

            //stop stage 1
            for (int i = 0; i < stageOne.Count; i++) {
                if (!stageOne[i].isStopped) stageOne[i].Stop();
            }
        }
        else if (panic >= 25 && panic < 50) {
            //play stage 1
            for (int i = 0; i < stageOne.Count; i++) {
                if (!stageOne[i].isPlaying) stageOne[i].Play();
            }

            //stop stage 2
            for (int i = 0; i < stageTwo.Count; i++) {
                if (!stageTwo[i].isStopped) stageTwo[i].Stop();
            }
        }
        else if (panic < 25) {
            //stop stage 1
            for (int i = 0; i < stageOne.Count; i++) {
                if (!stageOne[i].isStopped) stageOne[i].Stop();
            }
        }
    }

}
