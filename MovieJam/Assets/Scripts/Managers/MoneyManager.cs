using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Singleton<MoneyManager>
{
	const int STARTING_MONEY = 200;

    public int money;
    
	Text moneyText;
    Text fundsText;

    override public void Init()
    {
		PreferencesManager.Instance.SetInitialValue ("money", STARTING_MONEY);
    }

	public void LinkScore()
	{
		Transform gameView = GameObject.Find ("GameView").transform;
		moneyText = gameView.Find ("UI/GameMenu/Score").gameObject.GetComponent<Text>();
		moneyText.text = "ZION_$: " + GetMoney();
	}

    public void AddMoney(int addMoney)
    {
		int money = GetMoney ();
		int resultingMoney = money + addMoney;
		PreferencesManager.Instance.SetValue ("money", resultingMoney);
        UpdateMoneyText();
    }

	public void SubtractMoney(int subtractMoney)
	{
		int money = GetMoney ();
		int resultingMoney = money - subtractMoney;
		PreferencesManager.Instance.SetValue ("money", resultingMoney);
		UpdateMoneyText();
	}


    public void UpdateMoneyText()
    {          
        moneyText.text = "ZION_$: " + GetMoney();

    }

    public void notEnougFundsText(string unit)
    {
		Debug.Log ("is this even called?");
        //fundsText.text = "You do not have enough ZION_$ to buy:" + unit;
    }


    public int GetMoney()
    {
		return PreferencesManager.Instance.Get ("money");
    }
	
	
}
