using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCOntroller : MonoBehaviour {
Player _player;
	// Use this for initialization
	void Start () {
		_player=GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
		{
			_player.moveForward();
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			//back
			_player.moveBack();
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			//left
			_player.rotationLeft();
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			//right
			_player.rotationRight();
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//left
			_player.Jump();
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			//left
			_player.fire();
		}

	}
}
