using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFases : MonoBehaviour {

	[SerializeField]
	private Text moedasLevel;
	// Use this for initialization
	void Start () {
		ScoreManager.instance.UpdateScore();
		moedasLevel.text = PlayerPrefs.GetInt("moedasSave").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
