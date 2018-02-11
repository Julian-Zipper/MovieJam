using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Singleton<MoneyManager>
{
    
    public int money;
    [SerializeField]
     Text moneyText;
   


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


    public int getMoney()
    {
        return PlayerPrefs.GetInt("money");
    }
	
	
}
