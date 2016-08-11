using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioControl : MonoBehaviour {
	public static AudioControl S;
	void Awake(){S = this;}

	//VARIABLES___________________//
	public Button audioButton;
	public Text audioText;
	public bool sound = true;

	public AudioSource explosion;
	public AudioSource firebreath;
	public AudioSource weird;

	public void InitializeAudio(){
		audioButton.onClick.RemoveAllListeners ();
		audioButton.onClick.AddListener (delegate {
			ToggleSound();
		});
	}

	public void ToggleSound(){
		switch (sound) {
		case true:
			explosion.mute = true;
			firebreath.mute = true;
			weird.mute = true;
			audioText.text = "PLAY AUDIO";
			sound = false;
			break;
		case false:
			explosion.mute = false;
			firebreath.mute = false;
			weird.mute = false;
			audioText.text = "MUTE AUDIO";
			sound = true;
			break;
		}
	}

	public void PlayExplosion(){
		explosion.Play();
	}

	public void PlayWeird(){
		weird.Play();
	}

	public void PlayFireBreath(){
		firebreath.Play ();
	}

	public void StopFireBreath(){
		firebreath.Stop ();
	}

}
