using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public void OnPauseClick()
	{
		//AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
		gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void OnResumeClick()
	{
		//AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void OnQuitClick()
	{
		//AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
		gameObject.SetActive(false);
		Time.timeScale = 1;
		GameManager.Instance.QuitGame();
	}
}
