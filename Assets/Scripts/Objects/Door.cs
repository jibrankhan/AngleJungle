﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject _GM;
	public GameObject Flame;
	public GameObject EyeMask;
	public GameObject DoorParticle;

	// Use this for initialization
	void Start () 
	{
		_GM.GetComponent<GameManager> ().door = gameObject;
		Flame.SetActive (true);
		EyeMask.SetActive (false);
	}

	/// <summary>
	/// Opens the door.
	/// </summary>
	public void OpenDoor()
	{
		//Flame.SetActive (false);
		//EyeMask.SetActive (true);
		//DoorParticle.SetActive(true);
		if(Global.antiCheater <= 0)
			_GM.GetComponent<GameManager> ().DoorOpened ();
	}

	/// <summary>
	/// Doors the opened.
	/// </summary>
	public void DoorOpened()
	{
		Flame.SetActive (false);
		EyeMask.SetActive (true);
		DoorParticle.SetActive(true);
	}

	/// <summary>
	/// Closes the door.
	/// </summary>
	public void CloseDoor()
	{
		//Flame.SetActive (true);
		//EyeMask.SetActive (false);
		//DoorParticle.SetActive(false);
		_GM.GetComponent<GameManager> ().DoorClosed ();
	}
}
