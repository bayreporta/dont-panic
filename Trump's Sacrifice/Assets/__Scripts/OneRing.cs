﻿using UnityEngine;
using System.Collections;

public class OneRing : MonoBehaviour {
    public static OneRing S;
    void Awake() {
        S = this;
        InitializeGame();
    }

    //GAME CONTROL_________________________________
    public bool gameActive = false;
    public int daysLeft;
    public float panic;


    //SCREEN CONTROL_________________________________
    public GameObject titleScr;
    public GameObject introScr;
    public GameObject gameScr;
    public GameObject gameOverScr;

    void InitializeGame() {
        //dicts
        DictControl.S.InitializeDictionaries();

        //canvases
        TitleCanvas.S.InitializeCanvas();
        IntroCanvas.S.InitializeCanvas();
        GameCanvas.S.InitializeCanvas();
        GameOverCanvas.S.InitializeCanvas();

		//turn off screens
		introScr.SetActive(false);
		gameScr.SetActive(false);
		gameOverScr.SetActive(false);

        //controls
        ParticleControl.S.InitializeParticleSystem();

    }

    public void StartGame() {
        //initialize game variables
        gameActive = true;
        daysLeft = 100;
        panic = 0;

        //initialize game UI
        GameCanvas.S.UpdatePanic(panic);
        GameCanvas.S.UpdateDaysLeft(daysLeft);

		//graphics init
		GameControl.S.mouthClosed.SetActive(true);
		GameControl.S.mouthOpen.SetActive(false);
		GameCanvas.S.warning.gameObject.SetActive (false);
		GameCanvas.S.trumpism.text = "";

        //Start game calculations
        Invoke("StartGameDelay", 1f);

    }

    public void StartGameDelay() {SpeedControl.S.TimeAdvance(true);}

    public void AdvanceGame() {

    }

    public void GameOver() {

    }

}
