using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public void OnPauseClick()
	{
		//GameManager.QuitGame ();
		gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void OnResumeClick()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void OnQuitClick()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1;
		GameManager.Instance.QuitGame();
	}
}
