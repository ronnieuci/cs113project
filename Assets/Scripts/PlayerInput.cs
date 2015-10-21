﻿using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	//Keys
	public KeyCode up,down,left,right,move,clear,shiftcw,shiftccw,swap,temp;
	public ShapesManager sm;
	public float x,y;
	
	private string direction;
	public GameObject cursor;
	
	void Awake()
	{
		direction = "U";
		x += 0.5f;
	}
	
	void Start()
	{
		cursor.transform.localPositionTo(Constants.MoveAnimationMinDuration,new Vector3(x,y,0));
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (left) )	 {if (x>0.5f){ cursor.transform.localPositionTo(Constants.MoveAnimationMinDuration,new Vector3(x-1,y,0)); x-=1;}}
		if (Input.GetKeyDown (right))	 {if (x<6){ cursor.transform.localPositionTo(Constants.MoveAnimationMinDuration,new Vector3(x+1,y,0)); x+=1;}}
		if (Input.GetKeyDown (up)) 		 {if (y<7){ cursor.transform.localPositionTo(Constants.MoveAnimationMinDuration,new Vector3(x,y+1,0)); y+=1;}}
		if (Input.GetKeyDown (down)) 	 {if (y>0){ cursor.transform.localPositionTo(Constants.MoveAnimationMinDuration,new Vector3(x,y-1,0)); y-=1;}}
		if (Input.GetKeyDown (clear)) 	 {sm.ResetBoard(); }
		if (Input.GetKeyDown (shiftcw))  {RotateBoardCW();}
		if (Input.GetKeyDown (shiftccw)) {RotateBoardCCW();}
		if (Input.GetKeyDown (swap)) 	 {SwapPieces();}
		
	}
	
	void RotateBoardCW(){
		if (direction == "U") 	   {direction = "R"; sm.SetGravity (direction);}
		else if (direction == "R") {direction = "D"; sm.SetGravity (direction);}
		else if (direction == "D") {direction = "L"; sm.SetGravity (direction);}
		else if (direction == "L") {direction = "U"; sm.SetGravity (direction);}
		cursor.transform.Rotate (new Vector3 (0, 0, 90));
		temp=up; up=right; right=down; down=left; left=temp;
	}
	
	void RotateBoardCCW(){
		if (direction == "U") 	   {direction = "L"; sm.SetGravity (direction);}
		else if (direction == "L") {direction = "D"; sm.SetGravity (direction);}
		else if (direction == "D") {direction = "R"; sm.SetGravity (direction);}
		else if (direction == "R") {direction = "U"; sm.SetGravity (direction);}
		cursor.transform.Rotate(new Vector3(0,0,-90));
		temp=up; up=right; right=down; down=left; left=temp;
	}
	
	void SwapPieces(){
		
	}
	
	
	public Vector2 getCursorLocation()
	{
		return new Vector2 (x, y);
	} 
}