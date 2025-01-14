﻿using UnityEngine;
using System.Collections;

public class cursorInput : MonoBehaviour {


	public KeyCode select;
	public GameObject cursor, chsprite, info;
	public RuntimeAnimatorController[] sprites;
	public Sprite[] spInfo;
	public Color tint;
	public int character,player;

	private Vector3 move;
	private CharacterController characterController;
	private defaultControls dc = new defaultControls();

	// Use this for initialization
	void Start () {
		character = -1;
		tint = Color.cyan;
		characterController = GetComponent<CharacterController>();
		dc.setControls (player);
		select = dc.swap;
	}

	// Update is called once per frame
	void Update () {

		move.x = 0;
		move.y = 0;

		
		if(cursor.transform.position.x > -17.5f)
			move.x = Input.GetAxis ("L_XAxis_"+player.ToString()) * 20;
		else if(cursor.transform.position.x < 17.5f)
			move.x = Input.GetAxis ("L_XAxis_"+player.ToString()) * 20;

		if(cursor.transform.position.y < 10)
			move.y = Input.GetAxis ("L_YAxis_"+player.ToString()) * -20;
		else if(cursor.transform.position.y > -10)
			move.y = Input.GetAxis ("L_YAxis_"+player.ToString()) * -20;


		characterController.Move(move * Time.deltaTime);
		if (cursor.transform.position.y > 10) {
			cursor.transform.position = new Vector3 (cursor.transform.position.x, 10,cursor.transform.position.z);
		}
		else if (cursor.transform.position.y < -10) {
			cursor.transform.position = new Vector3 (cursor.transform.position.x, -10,cursor.transform.position.z);
		}

		if (cursor.transform.position.x > 17.5f) {
			cursor.transform.position = new Vector3 (17.5f, cursor.transform.position.y,cursor.transform.position.z);
		}
		else if (cursor.transform.position.x < -17.5f) {
			cursor.transform.position = new Vector3 (-17.5f, cursor.transform.position.y,cursor.transform.position.z);
		}





		if (Input.GetKey(dc.up) && cursor.transform.position.y < 10) {
			cursor.transform.positionTo (0.005f, new Vector2(cursor.transform.position.x,cursor.transform.position.y+0.4f));
		}
		if (Input.GetKey (dc.down) && cursor.transform.position.y > -10) {
			cursor.transform.positionTo (0.005f, new Vector2(cursor.transform.position.x,cursor.transform.position.y-0.4f));
		}
		if (Input.GetKey (dc.left) && cursor.transform.position.x > -17.5f) {
			cursor.transform.positionTo (0.005f, new Vector2(cursor.transform.position.x-0.4f,cursor.transform.position.y));
		}
		if (Input.GetKey (dc.right) && cursor.transform.position.x < 17.5f) {
			cursor.transform.positionTo (0.005f, new Vector2(cursor.transform.position.x+0.4f,cursor.transform.position.y));
		}

		showChar (character);
	}

	public RaycastHit2D getCursorPosition(){
		Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(cursor.transform.position));
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
		return hit;
	}

	public void showChar(int c)
	{
		var a = chsprite.GetComponent<Animator>();
		info.SetActive (true);
		var b = info.GetComponent<SpriteRenderer> ();
		if (c >= 0){
			a.runtimeAnimatorController = sprites[c];
			b.sprite = spInfo[c];
		}
	}
}
