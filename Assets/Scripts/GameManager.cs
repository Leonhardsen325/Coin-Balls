using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	//bola
	private GameObject [] bola;
	// cria as bolas
	public int bolasNum = 2;
	// numero de chutes da bola
	public int bolasEmCena = 0;
	//controla quantas bolas existem na cena
	public Transform pos;
	// define onde a bola sera criada
	public bool win;
	// Define quando o painel deve aparecer em caso de vitoria
	public int tiro = 0;
	//Define o numero de tiros da bola
	//public int ondeEstou;
	//Identifica em qual cena o jogo está
	public bool jogoComecou;

	void Awake(){

		if(instance == null){

			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy (gameObject);
		}

		SceneManager.sceneLoaded += Carrega;

		pos = GameObject.Find("StartPos").GetComponent<Transform>();
	}

	void Carrega(Scene cena, LoadSceneMode modo){

		if(OndeEstou.instance.fase != 4){
			
			pos = GameObject.Find("StartPos").GetComponent<Transform>();
			StartGame();
		}
	}

	void Start () {

		StartGame();
		ScoreManager.instance.GameStartScoreM();
		
	}
	
	void Update () {

		ScoreManager.instance.UpdateScore();
		UIManager.instance.UpdateUI ();

		NascBolas();
		//faz com o jogo apresente o Game Over quando o numero de bolas chegar a 0
		
		if(bolasNum <= 0){

			GameOver();
			
		}

		if(win == true){

			WinGame();
		}
		
	}

	void NascBolas(){

		if (OndeEstou.instance.fase >= 1)
		{

			if (bolasNum > 0 && bolasEmCena == 0 && Camera.main.transform.position.x <= 0.010f)
			{
				Instantiate(bola[OndeEstou.instance.bolaEmUso], new Vector2(pos.position.x,pos.position.y),Quaternion.identity);
				bolasEmCena += 1;
				tiro = 0;
			}
		}

		else
		{
			if (bolasNum > 0 && bolasEmCena == 0)
			{
				Instantiate(bola[OndeEstou.instance.bolaEmUso], new Vector2(pos.position.x,pos.position.y),Quaternion.identity);
				bolasEmCena += 1;
				tiro = 0;
			}
		}	
		
	}

	void GameOver(){

		UIManager.instance.GameOverUI();
		jogoComecou = false;
	}

	void WinGame(){

		UIManager.instance.WinGameUI();
		jogoComecou = false;
	}

	void StartGame(){

		jogoComecou = true;
		bolasNum = 10;
		bolasEmCena = 0;
		win = false;
		UIManager.instance.StartUI();
	}
}
