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
    [SerializeField]
    APU apu;
    [SerializeField]
    Morpheus morpheus;
    [SerializeField]
    Trinity trinity;
    [SerializeField]
    Oracle oracle;
    [SerializeField]
    Neo neo;
    [SerializeField]
    Transform infantryUnitsHolder;

    List<Infantry> infantryUnits;

    override public void Init()
	{
		_menu = canvas.Find("MenuView").GetComponent<Menu>();
		_menu.Init();
		_matrixGame = canvas.Find("GameView").GetComponent<MatrixGame>();      
		_matrixGame.Init();
        apu.Init();
        morpheus.Init();
        trinity.Init();
        oracle.Init();
        neo.Init();
        infantryUnits = new List<Infantry>();
        for(int i = 0; i < infantryUnitsHolder.childCount; i++)
        {
            infantryUnits.Add(infantryUnitsHolder.GetChild(i).GetComponent<Infantry>());
            infantryUnits[i].Init();
        }
        for(int i = 0; i < ShopManager.Instance.GetUnitLevel(Unit.Type.Infantry); i++)
        {
            infantryUnits[i].Show();
        }

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

    public Unit GetUnit(Unit.Type unitType)
    {
        switch (unitType)
        {
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
        return null;
    }

	public void AddInfantry(GameObject infantry)
	{
		_matrixGame.AddInfantry (infantry);
	}

	public GameObject AcquireTarget()
	{
		GameObject target = _matrixGame.GetSentinel ();
		return target;
	}

    public List<Infantry> GetInfantryUnits()
    {
        return infantryUnits;
    }
}