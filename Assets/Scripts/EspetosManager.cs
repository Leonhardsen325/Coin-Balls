using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspetosManager : MonoBehaviour {

	private SliderJoint2D espetos;
	private JointMotor2D aux;

	void Start () {

		espetos = GetComponent<SliderJoint2D> ();
		aux = espetos.motor;
		
	}
	
	
	void Update () {

		if(espetos.limitState == JointLimitState2D.UpperLimit){
			aux.motorSpeed = Random.Range (-1, -5);
			espetos.motor = aux;
		}

		if(espetos.limitState == JointLimitState2D.LowerLimit){
			aux.motorSpeed = Random.Range (1, 5);
			espetos.motor = aux;
		}
		
	}
}
