﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {

	public GameObject[] buttonsList;

	public int currentLevelProgress = 1;

	private GameObject musicManager;

	bool showLoading = false;

	// Use this for initialization
	void Start () 
	{
		musicManager = GameObject.FindGameObjectWithTag (Global.TAG_MUSIC_MANAGER);
		musicManager.GetComponent<MusicManager> ().PlayMAPSound ();

		showLoading = false;
		SaveLoad.Load ();
		currentLevelProgress = SaveLoad.data.LevelProgress;
		//btn_1.GetComponent<Button> ().interactable = false;

		for(int i=0;i<currentLevelProgress - 1;i++) 
		{
			buttonsList [i].GetComponent<Button> ().interactable = true;
			buttonsList [i].GetComponent<StageButton> ().ShowStar ();
		}

        if(currentLevelProgress <= 30)
            buttonsList [currentLevelProgress - 1].GetComponent<Button> ().interactable = true;
	}

	public void LoadStage(string stageName)
	{
		musicManager.GetComponent<MusicManager> ().PlayClickButton ();
		StartCoroutine (LoadStageCo(stageName));
	}

	public void LoadStart()
	{
		musicManager.GetComponent<MusicManager> ().PlayClickButton ();
		SceneManager.LoadScene (Global.SCENE_START);
	}

    public void LoadTreasure() 
	{
		musicManager.GetComponent<MusicManager> ().PlayCreakClickButton ();
		SceneManager.LoadScene(Global.SCENE_TREASURE);
    }

	IEnumerator LoadStageCo(string stageName)
	{
		showLoading = true;
		float fadeTime = GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (stageName);
	}

	void OnGUI()
	{
		if (showLoading) 
		{
			GUIStyle loadingStyle = new GUIStyle ();
			Font myfont = (Font)Resources.Load ("fonts/Asap-Medium", typeof(Font));
			loadingStyle.font = myfont;
			loadingStyle.fontSize = 60;
			loadingStyle.alignment = TextAnchor.MiddleCenter;
			loadingStyle.normal.textColor = Color.white;
			loadingStyle.hover.textColor = Color.white;
			GUI.depth = -1001;																// make the black texture render on top (drawn last)
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Loading....", loadingStyle);
		}
	}
}
