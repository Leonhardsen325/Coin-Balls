﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour {

	public GameObject bombaRep;

	void Start () {

		bombaRep = GameObject.Find ("BombaR");
			
	}

	void Update () {

		StartCoroutine (Vida());
		
	}		

	IEnumerator Vida(){

		
		yield return new WaitForSeconds (0.5f);
		Destroy(bombaRep.gameObject);
		Destroy(this.gameObject);
		
	}
}
