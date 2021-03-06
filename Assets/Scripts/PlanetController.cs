﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour {


	public ulong population;
	public string identifier = "My planet, foo";

	private Vector3 myScale;

	void Start() {
		myScale = transform.localScale;
	}

	void OnMouseDown() {
		if(!GameManager.planetFrom){
			GameManager.planetFrom = gameObject;
			transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, transform.localScale.z * 1.25f);
		} else {
			GameManager.planetTo = gameObject;
			GameManager.instance.TransferPopulation();
		}

		UIController.ui.UpdateSelectedPlanetInfo(this);
	}

	public void receivePopulation(ulong populationToAdd){
		print("populationToAdd: " + populationToAdd);
		if(populationToAdd > 0) {
			GetComponent<AudioSource>().Play();
			population = population + populationToAdd;
		}
	}

	public void distributePopulation(ulong populationToDistribute){
		if(tag == "Home"){			
			population = population - (ulong)Mathf.Clamp(populationToDistribute, 0, population - 2);
		} else {
			population = population - populationToDistribute;
		}
		ResetScale();
	}

	public void ResetScale() {
		transform.localScale = myScale;
	}
}
