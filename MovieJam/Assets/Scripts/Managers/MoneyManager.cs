using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Singleton<MoneyManager>
{
    
    public int money;
    [SerializeField]
     Text moneyText;
    [SerializeField]
    Text fundsText;
   


    override public void Init()
    {
       
        moneyText.text = "ZION_$: " + getMoney();
        setMoney(money);
        getMoney();
    }

    public void setMoney(int money)
    {
        PlayerPrefs.SetInt("money", money);
        updateMoneyText();
    }


    public void updateMoneyText()
    {          
        moneyText.text = "ZION_$: " + getMoney();

    }

    public void notEnougFundsText(string unit)
    {
       
        fundsText.text = "You do not have enough ZION_$ to buy:" + unit;
    }


    public int getMoney()
    {
        return PlayerPrefs.GetInt("money");
    }
	
	
}
