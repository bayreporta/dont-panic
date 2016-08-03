using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class IntroCanvas : MonoBehaviour {
    public static IntroCanvas S;
    void Awake() { S = this; }

    //CANVAS ITEMS______________________________________________
    public Canvas canvas;
    public CanvasGroup canvasGroup;

}
