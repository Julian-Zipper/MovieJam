using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	Menu _menu;
	MatrixGame _matrixGame;
	//TimerForTimeGameMode _timerForTimeGameMode;
	//PreferencesManager _preferencesManager;

	[SerializeField]
	Transform canvas;

	override public void Init()
	{
		_menu = canvas.Find("MenuView").GetComponent<Menu>();
		_menu.Init();
		_matrixGame = canvas.Find("GameView").GetComponent<MatrixGame>();      
		_matrixGame.Init();
		//_timerForTimeGameMode = _ballGame.transform.Find("GameTimer").GetComponent<TimerForTimeGameMode>();
	}
	 
	public void StartGame()
	{
		Debug.Log ("starting game");
		_menu.gameObject.SetActive(false);
		_matrixGame.gameObject.SetActive(true);
		//Animates game
		//iTween.MoveFrom(_ballGame.gameObject, iTween.Hash("position", _ballGame.gameObject.transform.localPosition - new Vector3(0, 1000, 0), "islocal", true, "time", 1));

		//_ballGame.Prepare();
	}

	public void QuitGame ()
	{
		_matrixGame.gameObject.SetActive (false);
		_menu.gameObject.SetActive (true);
		_menu.Reset();
	}
}