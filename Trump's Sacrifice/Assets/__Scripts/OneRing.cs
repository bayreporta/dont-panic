using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public int timesDontPanic;


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
		timesDontPanic = 0;

		//init canvas
		gameOverScr.SetActive(false);
		GameOverCanvas.S.canvasGroup.alpha = 0;
		GameOverCanvas.S.canvasGroup.interactable = false;

        //initialize game UI
        GameCanvas.S.UpdatePanic(panic);
        GameCanvas.S.UpdateDaysLeft(daysLeft);

		//init variables
		GameControl.S.usedTrumpisms = new List<string>();

		//graphics init
		GameControl.S.mouthClosed.SetActive(true);
		GameControl.S.mouthOpen.SetActive(false);
		GameCanvas.S.warning.gameObject.SetActive (false);
		GameCanvas.S.trumpism.text = "";

		//reset particle systems
		ParticleControl.S.ResetParticleSystems();

        //Start game calculations
        Invoke("StartGameDelay", 1f);

    }

    public void StartGameDelay() {SpeedControl.S.TimeAdvance(true);}

    public void AdvanceGame() {

    }

	public void GameOver(int end) {
		//bring in the canvas
		gameOverScr.SetActive(true);
		StartCoroutine(GameOverCanvas.S.TransitionCanvas(1));

		//lets disable a few things
		GameCanvas.S.warning.gameObject.SetActive (false);
		GameCanvas.S.trumpism.text = "";

		switch (end) {
		case 0:
			GameOverCanvas.S.endingText.text = "TRUMP DESTROYED AMERICA! SAD!";
			break;
		case 1:
			GameOverCanvas.S.endingText.text = "YOU SAVED AMERICA FROM TRUMP! WINNING!";
			break;
		}
		GameOverCanvas.S.panicText.text = "You didn't panic " + timesDontPanic + " times.";
    }

}
