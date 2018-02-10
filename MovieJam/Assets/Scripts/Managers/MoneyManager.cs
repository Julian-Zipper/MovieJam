using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Singleton<GameManager>
{
    
    public int money;
    Text moneyText;

    private void Start()
    {
        moneyText = gameObject.GetComponent<Text>();
        moneyText.text = "ZION_$: " + getMoney();
    }

    public void setMoney(int money)
    {
        PlayerPrefs.SetInt("money", money);
    }


    public void updateMoneyText()
    {          
        moneyText.text = "ZION_$: " + getMoney();

    }


    public int getMoney()
    {
        return PlayerPrefs.GetInt("money");
    }
	
	
}
