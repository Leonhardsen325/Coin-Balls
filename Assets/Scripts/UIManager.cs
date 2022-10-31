using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text pontosUI,bolasUI;
	private GameObject losePainel,winPainel,pausePainel;
	public Button pauseBtn,pauseBTN_Return,pauseBtnLevel;
	private Button btnNovamenteLose,btnLevelLose;//Botões de Lose
	private Button btnLevelWin,btnNovamenteWin,btnAvancaWin;//botões de Win
	
	public int moedasNumAntes,moedasNumDepois,resultado;
	
	//Faz com que o código não se destrua no meio da execução
	void Awake(){
		if(instance == null){
			
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else{
			Destroy (gameObject);
		}

		SceneManager.sceneLoaded += Carrega;

		PegaDados();
	}
	//Carrega os paineis, assim como os botões, as pontuações e o número de bolas disponiveis
	void Carrega(Scene cena, LoadSceneMode modo){

		PegaDados();
	}

	void PegaDados(){
		if(OndeEstou.instance.fase !=4){
			//Elementos da UI pontos e bolas
			pontosUI = GameObject.FindGameObjectWithTag("Pontos").GetComponent<Text>();
			bolasUI = GameObject.Find("bolasUI").GetComponent<Text>();
			//Paineis
			losePainel = GameObject.Find("LosePainel");
			winPainel = GameObject.Find("WinPainel");
			pausePainel = GameObject.Find("PausePainel");
			//Botões de pause
			pauseBtn = GameObject.Find ("Pause").GetComponent<Button>();
			pauseBTN_Return = GameObject.Find ("Play").GetComponent<Button>();
			pauseBtnLevel = GameObject.Find ("MenuFasesPAUSE").GetComponent<Button>();

			//Botões de Lose
			btnNovamenteLose = GameObject.Find ("NovamenteLOSE").GetComponent<Button>();
			btnLevelLose = GameObject.Find ("MenuFasesLOSE").GetComponent<Button>();
			//Botões de Win
			btnLevelWin = GameObject.Find("MenuFasesWIN").GetComponent<Button>();
			btnNovamenteWin = GameObject.Find("NovamenteWIN").GetComponent<Button>();
			btnAvancaWin = GameObject.Find("AvançarWIN").GetComponent<Button>();

			//Eventos de click dos botões
			
			//Eventos de pause
			pauseBtn.onClick.AddListener(Pause);
			pauseBTN_Return.onClick.AddListener(PauseReturn);
			pauseBtnLevel.onClick.AddListener(Levels);

			//you lose
			btnNovamenteLose.onClick.AddListener (JogarNovamente);
			btnLevelLose.onClick.AddListener(Levels);
			
			//Evento you win
			btnLevelWin.onClick.AddListener(Levels);
			btnNovamenteWin.onClick.AddListener(JogarNovamente);
			btnAvancaWin.onClick.AddListener(ProximaFase);

			moedasNumAntes = PlayerPrefs.GetInt("moedasSave");
		}
	}
	public void StartUI(){

		LigaDesligaPainel();
	}

	//Atualiza o painel de Score e de bolas
	public void UpdateUI(){

		pontosUI.text = ScoreManager.instance.moedas.ToString();
		bolasUI.text = GameManager.instance.bolasNum.ToString();
		moedasNumDepois = ScoreManager.instance.moedas;
	}
	//Desabilita o painel de Game Over com base na informação que for passada  pra ele
	public void GameOverUI(){
		
		losePainel.SetActive(true);	
	}

	public void WinGameUI(){

		winPainel.SetActive(true);
	}

	void LigaDesligaPainel(){

		StartCoroutine(tempo());
	}
	// Pause e PauseReturn ativam as animações para que o painel apareça e suma
	void Pause(){

			pausePainel.SetActive (true);
			pausePainel.GetComponent<Animator>().Play("MoveUI_PAUSE");
			Time.timeScale = 0;
	}

	 void PauseReturn(){

		pausePainel.GetComponent<Animator>().Play("MoveUI_PAUSER");
		Time.timeScale = 1;
		StartCoroutine (EsperaPause());
	}
	//Define o tempo que o menu de pause deve ser desativado
	IEnumerator EsperaPause(){

		yield return new WaitForSeconds(0.8f);
		pausePainel.SetActive(false);
	}
	//Define o tempo para desligar os paineis antes do jogo começar, de modo que eles possam ser carregados posteriormente
	IEnumerator tempo(){

		yield return new WaitForSeconds(0.001f);
		losePainel.SetActive(false);
		winPainel.SetActive(false);
		pausePainel.SetActive(false);
	}
	//Se jogador perde ele perde 10 moedas, senão ele simplesmente recarrega a fase
	public void JogarNovamente(){

		if(GameManager.instance.win == false){
			
			SceneManager.LoadScene(OndeEstou.instance.fase);
			resultado = moedasNumDepois - moedasNumAntes;
			ScoreManager.instance.PerdeMoedas (resultado);
			resultado = 0;
		}
		else{
			
			SceneManager.LoadScene(OndeEstou.instance.fase);
			resultado = 0;
		}	
	}
	//Se não ganhar ele perde as moedas e chama a cena dos leveis e se ganhar ele carrega a cena
	void Levels(){

		if(GameManager.instance.win == false){

			resultado = moedasNumDepois - moedasNumAntes;
			ScoreManager.instance.PerdeMoedas (resultado);
			resultado = 0;
			SceneManager.LoadScene (4);
		}
		else{

			resultado = 0;
			SceneManager.LoadScene(4);
		}
	}

	void ProximaFase(){

		if (GameManager.instance.win == true)
		{
			int temp = OndeEstou.instance.fase + 1;
			SceneManager.LoadScene(temp);
		}
	}

}
