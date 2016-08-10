using UnityEngine;
using System.Collections;

public class IntroControl : MonoBehaviour {
	public static IntroControl S;
	void Awake(){S = this;}

	//VARIABLES_________________________//
	public bool titleScr = true;
	public bool introScr = false;

	void Update(){
		if (titleScr == true) {
			if (Input.anyKeyDown) {
				StartCoroutine (TitleCanvas.S.TransitionCanvas (0));
				StartCoroutine (IntroCanvas.S.TransitionCanvas (1));
				titleScr = false;
				introScr = true;
			}
		}
	}

}
