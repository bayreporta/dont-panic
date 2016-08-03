using UnityEngine;
using System.Collections;

public class OneRing : MonoBehaviour {
    public static OneRing S;
    void Awake() { S = this; }

    //SCREEN CONTROL_________________________________
    public GameObject titleScr;
    public GameObject introScr;
    public GameObject gameScr;
    public GameObject gameOverScr;

    void Start() {
        InitializeGame();
    }

    void InitializeGame() {
        //dicts
        DictControl.S.InitializeDictionaries();

        //canvases
        TitleCanvas.S.InitializeCanvas();
        IntroCanvas.S.InitializeCanvas();
        GameCanvas.S.InitializeCanvas();
        GameOverCanvas.S.InitializeCanvas();
    }

    public void StartGame() {

    }

}
