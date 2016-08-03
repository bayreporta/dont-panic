using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameCanvas : MonoBehaviour {
    public static GameCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public Canvas canvas;
    public CanvasGroup canvasGroup;
}
