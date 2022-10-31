using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int moedas;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else{
			Destroy (gameObject);
		}
	}
	//inicia o código e o verifica para que continue funcionando
	public void GameStartScoreM(){
		//if verifica se o jogador ja tem moedas na sua pontuação, se tiver o jogo continua como está, se não tiver ele inicia com 100 moedas
		if(PlayerPrefs.HasKey("moedasSave")){
			moedas = PlayerPrefs.GetInt("moedasSave");
		}
		else{
			moedas = 100;
			PlayerPrefs.SetInt("moedasSave", moedas);
		}
	}
	//garante que a pontuação seja exibida na tela
	public void UpdateScore(){

		moedas = PlayerPrefs.GetInt("moedasSave");

	}
	
	public void ColetaMoedas(int coin){

		moedas += coin;
		SalvaMoedas(moedas);
	}

	public void PerdeMoedas(int coin){

		moedas -= coin;
		SalvaMoedas(moedas);
	}

	public void SalvaMoedas(int coin){

		PlayerPrefs.SetInt("moedasSave", coin);
	}
}
