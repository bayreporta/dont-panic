using UnityEngine;
using System.Collections;

public class OneRing : MonoBehaviour {
    public static OneRing S;
    void Awake() { S = this; }

    //VARIABLES_________________________________


    void Start() {
        InitializeGame();
    }

    void InitializeGame() {
        DictControl.S.InitializeDictionaries();
    }

    public void StartGame() {

    }

}
