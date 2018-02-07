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
		Invoke("SpawnSentinel", 0.5f);
		Invoke("SpawnSentinel", 2.5f);
		Invoke("SpawnSentinel", 6f);
		Invoke("SpawnSentinel", 8f);
		Invoke("SpawnSentinel", 9.5f);
	}

	// TEST METHOD
	void SpawnSentinel()
	{
		GameObject newSentinel = GameObject.Instantiate (Resources.Load<GameObject> ("Sentinel/Sentinel"));
		newSentinel.transform.position = new Vector3 (Random.Range(-8, 1), newSentinel.transform.position.y, 0);
	}

	public void QuitGame ()
	{
		ViewManager.Instance.ShowMenu();
		_menu.Reset();
	}
}