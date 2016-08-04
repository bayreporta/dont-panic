using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpeedControl : MonoBehaviour {
    public static SpeedControl S;
    void Awake() { S = this; }

    //VARIABLES______________________________________________
    public float daySpeed = 1f;
    public float panicSpeed = 1f;
    public float trumpismSpeed = 0.2f;

    public void TimeAdvance(bool x) {
        if (x == true) {
            StartCoroutine("DaySpeed");
            StartCoroutine("PanicSpeed");
            StartCoroutine("TrumpismSpeed");
        } else {
            StopCoroutine("DaySpeed");
            StopCoroutine("PanicSpeed");
            StopCoroutine("TrumpismSpeed");
        }
    }  

    public void RestoreOriginalPanicSpeed() {
        panicSpeed = 2f;
        GameControl.S.trumpismActive = false;
    }

    public IEnumerator DaySpeed() {
        while (OneRing.S.gameActive == true) {                          
            if (OneRing.S.daysLeft != 0) {
                OneRing.S.daysLeft -= 1;
                GameCanvas.S.UpdateDaysLeft(OneRing.S.daysLeft); //update UI 
            }
            else {

            }
            yield return new WaitForSeconds(daySpeed);
        }
    }

    public IEnumerator TrumpismSpeed() {
        while (OneRing.S.gameActive == true) {
            if (GameControl.S.trumpismActive == false) {
                float rand = Random.Range(0f, 1f);

                //if random chance happens Trumpism happens
                if (rand <= .1f) {                   

                    //determine panic speed based on time left
                    if (OneRing.S.daysLeft >= 76) { panicSpeed = .75f; }
                    else if (OneRing.S.daysLeft >= 51 && OneRing.S.daysLeft <= 75) { panicSpeed = .5f; }
                    else if (OneRing.S.daysLeft >= 26 && OneRing.S.daysLeft <= 50) { panicSpeed = .25f; }
                    else if (OneRing.S.daysLeft <= 25) { panicSpeed = .1f; }
                    Debug.Log("panicSpeed " + panicSpeed);

                    //toggle trumpism
                    GameControl.S.trumpismActive = true;

                    //wait x seconds before resetting
                    Invoke("RestoreOriginalPanicSpeed", 5f);

                    
                }
                //wait x seconds before disabling

            } 
            yield return new WaitForSeconds(trumpismSpeed);
        }
    }

    public IEnumerator PanicSpeed() {
        while (OneRing.S.gameActive == true) {
            if (OneRing.S.panic != 100) {
                OneRing.S.panic += 1;
                GameCanvas.S.UpdatePanic(OneRing.S.panic); //update UI 
            } else {

            }
            yield return new WaitForSeconds(panicSpeed);
        }
    }


}
