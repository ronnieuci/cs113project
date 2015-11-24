﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public ShapesManager player1,player2;
	public float pscore1, pscore2;
	public SoundManager sound;
	
	public IEnumerable<GameObject> getRandomBlocks(int attacker) {
		if (attacker == 1) {
			return( player2.shapes.getRandomBlocks(8));
		} 
		else {
			return( player1.shapes.getRandomBlocks(8));
		}
	}

	public IEnumerable<GameObject> getAllBlocks(int attacker) {
		if (attacker == 1) {
			return( player2.shapes.GetAllBlocks());
		} 
		else {
			return( player1.shapes.GetAllBlocks());
		}
	}

	public ShapesManager getOtherPlayer(int attacker) {
		if (attacker == 1) {
			return(player2);
		} 
		else {
			return(player1);
		}
	}

	public int loadCharacter(int player){
		string p;
		if (player == 1) {
			p = PlayerPrefs.GetString ("char1");
			print ("1"+p);
		} 
		else {
			p = PlayerPrefs.GetString ("char2");			
			print ("2"+p);
		}
		return charStrtoInt (p);
	}

	private int charStrtoInt(string p){
		if (p == "assassin"){
			return(1);
		}
		else if (p == "mage"){
			return(2);
		}
		else if (p == "warrior"){
			return(3);
		}
		else{
			return 0;
		}
	}

}
