using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameOverCanvas : MonoBehaviour {
    public static GameOverCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public GameObject canvas;
    public CanvasGroup canvasGroup;
	public Button button;
	public Text endingText;

	public void InitializeCanvas() {
		//configure buttons
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(delegate {OneRing.S.StartGame();});
        	
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
    }
}
