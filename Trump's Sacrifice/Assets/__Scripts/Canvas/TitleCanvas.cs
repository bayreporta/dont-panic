using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TitleCanvas : MonoBehaviour {
    public static TitleCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public GameObject canvas;
    public CanvasGroup canvasGroup;
    public Button playGame;

    public void InitializeCanvas() {
        //configure buttons
        playGame.onClick.RemoveAllListeners();
        playGame.onClick.AddListener(delegate { StartCoroutine(this.TransitionCanvas(0)); });
        playGame.onClick.AddListener(delegate { StartCoroutine(IntroCanvas.S.TransitionCanvas(1)); });
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
                break;
        }

        //disable Title Screen
        OneRing.S.titleScr.SetActive(false);
        OneRing.S.introScr.SetActive(true);
    }

}
