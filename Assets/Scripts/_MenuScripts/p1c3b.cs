﻿using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class p1c3b : MonoBehaviour {
	
	
	public Button b; 
	public Image selection; 
	public Sprite img; 
	public GameObject player; 
	
	
	public void OnMouseDown(){
		selection.sprite = img; 
		
		
		
		playerReady pr =  player.GetComponent<playerReady>();
		pr.p_ready = true; 
		pr.character = "mage";
	}
}