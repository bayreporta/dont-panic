using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameCanvas : MonoBehaviour {
    public static GameCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public GameObject canvas;
    public CanvasGroup canvasGroup;
    public Text panic;
    public Text daysLeft;
    public Button panicBut;
    public GameObject speechBubble;
    public Text trumpism;

    public void InitializeCanvas() {
        //configure buttons
        panicBut.onClick.RemoveAllListeners();
        panicBut.onClick.AddListener(delegate { GameControl.S.DontPanic(); });
    }

    public void UpdateDaysLeft(int day) {
        daysLeft.text = day + " days left";
    }

    public void UpdatePanic(int p) {
        panic.text = "Panic: " + p + "%";
    }

    public IEnumerator TransitionCanvas(int i) {
        switch (i) {
            case 0:
                while (canvasGroup.alpha > 0) {
                    canvasGroup.alpha -= Time.deltaTime * 2;
                    yield return null;
                }
                canvas.SetActive(false);
                canvasGroup.interactable = false;
                break;
            case 1:
                canvas.SetActive(true);
                canvasGroup.interactable = true;
                while (canvasGroup.alpha < 1) {
                    canvasGroup.alpha += Time.deltaTime * 2;
                    yield return null;
                }

                //start the game
                OneRing.S.StartGame();
                break;
        }
    }
}
