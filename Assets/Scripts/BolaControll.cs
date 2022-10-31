using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControll : MonoBehaviour {

	// Seta
	public GameObject setaGO;

	//Angulo
	public float zRotate;
	public bool liberaRot = false;
	public bool liberaTiro = false;

	//Força
	private Rigidbody2D bola;
	private float force = 0;
	public GameObject seta2Img;

	//paredes
	private Transform PAREDE_LQ,PAREDE_LD;

	//MorteBola Anim
	[SerializeField]
	private GameObject MorteBolaAnim;


	void Awake(){
		
		setaGO = GameObject.Find ("Seta1");
		seta2Img = setaGO.transform.GetChild(0).gameObject;
		setaGO.GetComponent<Image>().enabled = false;
		seta2Img.GetComponent<Image>().enabled = false;
		PAREDE_LD = GameObject.Find("PAREDE_LD").GetComponent<Transform>();
		PAREDE_LQ = GameObject.Find("PAREDE_LQ").GetComponent<Transform>();

	}

	
	void Start () {

		//Força
		bola = GetComponent<Rigidbody2D> ();

	}
	
	
	void Update () {
		
		RotacaoSeta();
		InputDeRotação();
		LimitaRotacao();
		PosicionaSeta ();

		//Força
		ControlaForca();
		AplicaForca();

		//Paredes
		Paredes();
	}

	void PosicionaSeta(){
		setaGO.GetComponent<Image>().rectTransform.position = transform.position;
	}

	void RotacaoSeta(){
		setaGO.GetComponent<Image>().rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
	}

	void InputDeRotação(){

		if(liberaRot == true){
			
			float moveY = Input.GetAxis ("Mouse Y");

			if(zRotate < 90){
				if(moveY > 0){
				zRotate += 2.5f;
				}
			}

			if(zRotate > 0){
				if(moveY < 0){
				zRotate -= 2.5f;
				}
			}	
		}
	}

	void LimitaRotacao(){

		if(zRotate >= 90){
			zRotate = 90;
		}

		if(zRotate <= 0){
			zRotate = 0;
		}
	}

	void OnMouseDown(){
		
		if(GameManager.instance.tiro == 0){

			liberaRot = true;
			setaGO.GetComponent<Image>().enabled = true;
			seta2Img.GetComponent<Image>().enabled = true;

		}			
	}

	void OnMouseUp(){
		
		liberaRot = false;
		setaGO.GetComponent<Image>().enabled = false;
		seta2Img.GetComponent<Image>().enabled = false;
		

		if(GameManager.instance.tiro == 0 && force > 0){
			
			
			liberaTiro = true;
			seta2Img.GetComponent<Image>().fillAmount = 0;
			GameManager.instance.tiro = 1;
			AudioManager.instance.SonsFXToca (1);
			StartCoroutine (MataBolaTempo());
		}

		
		
	}
	IEnumerator MataBolaTempo(){
		
		if (OndeEstou.instance.fase == 3)
		{
			yield return new WaitForSeconds (8f);
		}
		else
		{
			yield return new WaitForSeconds (5f);
		}
		
		Instantiate(MorteBolaAnim,transform.position, Quaternion.identity);
		AudioManager.instance.SonsFXToca (3);
		
		Destroy(this.gameObject);
		GameManager.instance.bolasEmCena -= 1;
		GameManager.instance.bolasNum -= 1;
	}
	//Força
	void AplicaForca(){

		float x = force * Mathf.Cos(zRotate * Mathf.Deg2Rad);
		float y = force * Mathf.Sin(zRotate * Mathf.Deg2Rad);

		if(liberaTiro == true){

			bola.AddForce(new Vector2(x, y));
			liberaTiro = false;
		}

	}

	void ControlaForca(){
		if(liberaRot == true){
			float moveX = Input.GetAxis ("Mouse X");

			if(moveX < 0){
				seta2Img.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
				force = seta2Img.GetComponent<Image>().fillAmount * 1000;
			}

			if(moveX > 0){
				seta2Img.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
				force = seta2Img.GetComponent<Image>().fillAmount * 1000;
			}
		}
	}
	//Desliga o kinematic para que a bola se mova pelo cenário
	void BolaDinamica(){
		
		this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
	}
	// Define como a bola deve morrer em relação as paredes da cena
	void Paredes(){

		if(this.gameObject.transform.position.x > PAREDE_LD.position.x){

			Destroy (this.gameObject);
			GameManager.instance.bolasEmCena -= 1;
			GameManager.instance.bolasNum -= 1;

		}
		
		if(this.gameObject.transform.position.x < PAREDE_LQ.position.x){

			Destroy (this.gameObject);
			GameManager.instance.bolasEmCena -= 1;
			GameManager.instance.bolasNum -= 1;

		}
	}
	//Ativa os inimigos atravéz da tag "morte" para matar a bola
	void OnTriggerEnter2D(Collider2D outro){

		if(outro.gameObject.CompareTag("morte")){
			if(outro.gameObject.CompareTag("ganhou")){

			GameManager.instance.win = true;
			AudioManager.instance.SonsFXToca(2);
			int temp = OndeEstou.instance.fase + 1;
			temp++;
			PlayerPrefs.SetInt("Fase" +temp,1);
			
		}	else{
			Instantiate(MorteBolaAnim,transform.position, Quaternion.identity);
			AudioManager.instance.SonsFXToca (3);
			Destroy (this.gameObject);
			GameManager.instance.bolasEmCena -= 1;
			GameManager.instance.bolasNum -= 1;
		}
		}	

		if(outro.gameObject.CompareTag("ganhou")){

			GameManager.instance.win = true;
			AudioManager.instance.SonsFXToca(2);
			int temp = OndeEstou.instance.fase + 1;
			temp++;
			PlayerPrefs.SetInt("Fase" +temp,1);
			
		}
		
	}

}
