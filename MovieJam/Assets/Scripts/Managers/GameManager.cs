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

    //TODO: Add all getters for unit gameobjects
    //[SerializeField]
    //Infantry infantry;

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
		_matrixGame.Reset ();
		_matrixGame.SetSpawning (true);
	}

	public void QuitGame ()
	{
		_matrixGame.SetSpawning (false);
		ViewManager.Instance.ShowMenu();
		_menu.Reset();
	}

    public void GetUnit(Unit.Type unitType)
    {
        /*
        switch (unitType)
        {
            case Unit.Type.Infantry:
                return infantry;
            case Unit.Type.APU:
                return apu;
            case Unit.Type.Morpheus:
                return morpheus;
            case Unit.Type.Trinity:
                return trinity;
            case Unit.Type.Oracle:
                return oracle;
            case Unit.Type.Neo:
                return neo;
        }
        */
    }
}