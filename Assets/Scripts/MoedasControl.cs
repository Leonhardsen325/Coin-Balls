using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedasControl : MonoBehaviour {
	
	//faz com que a bola ao bater na moeda adicione 10 pontos a pontuação e depois destrua a moeda
	void OnTriggerEnter2D(Collider2D outro){

		if(outro.gameObject.CompareTag("bola")){
			
			ScoreManager.instance.ColetaMoedas(10);
			AudioManager.instance.SonsFXToca (0);
			Destroy (this.gameObject);
		}
	}
}
