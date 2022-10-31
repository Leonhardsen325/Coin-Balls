using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerLevels : MonoBehaviour {

	[SerializeField]
	private Text moedasLevel;
	private Button btnReseta;

	void Start () {
		
		moedasLevel.text = PlayerPrefs.GetInt("moedasSave").ToString();

		btnReseta = GameObject.Find ("Resetar").GetComponent<Button>();

		btnReseta.onClick.AddListener(ResetaFase);
	}
	
	void ResetaFase(){

		PlayerPrefs.DeleteAll ();
	}
}
