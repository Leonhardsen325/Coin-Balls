using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomMenu : MonoBehaviour {
	
	private AudioSource musica;
	public Sprite somLigado, somDesligado;
	private Button btnSom;
	// Use this for initialization
	void Start () {
		
		musica = GameObject.Find("AudioManager").GetComponent<AudioSource>() as AudioSource;
		btnSom = GameObject.Find("SOM").GetComponent<Button>() as Button;
	}
	
	public void LigaDesligaSom(){

		musica.mute = !musica.mute;

		if(musica.mute == true){

			btnSom.image.sprite = somDesligado;
		}

		else
		{
			btnSom.image.sprite = somLigado;
		}
	}

}
