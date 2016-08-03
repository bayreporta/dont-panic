using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameOverCanvas : MonoBehaviour {
    public static GameOverCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public Canvas canvas;
    public CanvasGroup canvasGroup;
}
