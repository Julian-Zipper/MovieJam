using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : Singleton<ShopManager> {

    //Offense
    int _infantryLevel;
    int _APUlevel;
    int _morpheusLevel;
    int _trinityLevel;
    int _oracleLevel;
    int _neoLevel;

	List<Text> upgradeButtonTexts;
	List<Text> upgradeDescriptionTexts;

	Transform gameMenu;

	List<string> upgradeDescriptionNames;
	List<string> upgradeDescriptions;
	const string PURCHASE = "Purchase ";
	const string UPGRADE = "Lvl up ";
	const string NUM = "Current Lvl: ";

	const int INFANTRY_BASE_COST = 100;
	const int APU_BASE_COST = 200;
	const int MORPHEUS_BASE_COST = 500;
	const int TRINITY_BASE_COST = 1000;
	const int ORACLE_BASE_COST = 2000;
	const int NEO_BASE_COST = 13131;

	const float UPGRADE_POWER_MULTIPLIER = 0.05f;
	const float UPGRADE_POWER_INFANTRY_MULTIPLIER = 0.225f;

    public override void Init()
    {
		upgradeButtonTexts = new List<Text> ();
		upgradeDescriptionTexts = new List<Text> ();

		upgradeDescriptionNames = new List<string>{ "Infantry", "APU", "Morpheus", "Trinity", "Oracle", "Neo" };
		upgradeDescriptions = new List<string>{
			"Shoots with every click.\nAlso attracts Sentinels.",
			"Shoots automatically.\nAlso attracts some Sentinels.",
			"Shoots automatically.\nAlso attracts Sentinels.",
			"Shoots automatically.\nAlso attracts Sentinels.",
			"Shoots automatically.\nAlso attracts Sentinels.",
			"Shoots automatically.\nAlso attracts Lots of Sentinels." };

		PreferencesManager.Instance.SetInitialValue ("InfantryLevel", 0);
		PreferencesManager.Instance.SetInitialValue ("APULevel", 0);
		PreferencesManager.Instance.SetInitialValue ("MorpheusLevel", 0);
		PreferencesManager.Instance.SetInitialValue ("TrinityLevel", 0);
		PreferencesManager.Instance.SetInitialValue ("OracleLevel", 0);
		PreferencesManager.Instance.SetInitialValue ("NeoLevel", 0);

        _infantryLevel = PreferencesManager.Instance.Get("InfantryLevel");
        _APUlevel = PreferencesManager.Instance.Get("APULevel");
        _morpheusLevel = PreferencesManager.Instance.Get("MorpheusLevel");
        _trinityLevel = PreferencesManager.Instance.Get("TrinityLevel");
        _oracleLevel = PreferencesManager.Instance.Get("OracleLevel");
        _neoLevel = PreferencesManager.Instance.Get("NeoLevel");
    }

	public void SetupButtons()
	{
		gameMenu = GameObject.Find ("GameMenu").transform;

		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade1/Button/Text").gameObject.GetComponent<Text>());
		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade2/Button/Text").gameObject.GetComponent<Text>());
		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade3/Button/Text").gameObject.GetComponent<Text>());
		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade4/Button/Text").gameObject.GetComponent<Text>());
		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade5/Button/Text").gameObject.GetComponent<Text>());
		upgradeButtonTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade6/Button/Text").gameObject.GetComponent<Text>());

		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade1/Description").gameObject.GetComponent<Text> ());
		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade2/Description").gameObject.GetComponent<Text> ());
		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade3/Description").gameObject.GetComponent<Text> ());
		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade4/Description").gameObject.GetComponent<Text> ());
		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade5/Description").gameObject.GetComponent<Text> ());
		upgradeDescriptionTexts.Add(gameMenu.Find ("Upgrades/OffenseUpgrades/Upgrade6/Description").gameObject.GetComponent<Text> ());

		for (int i = 0; i < 6; i++)
		{
			Unit.Type typeNum = (Unit.Type) i;
			upgradeButtonTexts [i].text = GetButtonText (i);
			upgradeDescriptionTexts [i].text = GetDescriptionText(i);
		}
	}

	string GetButtonText(int number)
	{
		Unit.Type typeNum = (Unit.Type) number;
		int unitLevel = GetUnitLevel (typeNum);

		string verb = UPGRADE;
		if (unitLevel == 0)
		{
			verb = PURCHASE;
		}

		int cost = GetUnitCost(number);
		return (verb + upgradeDescriptionNames [number] + ":\n" + cost + " $");
	}

	string GetDescriptionText(int number)
	{
		Unit.Type typeNum = (Unit.Type) number;
		return (upgradeDescriptionNames [number] + ": " + upgradeDescriptions [number] + "\n" + NUM + GetUnitLevel (typeNum));
	}

	int GetUnitCost(int number)
	{
		Unit.Type typeNum = (Unit.Type) number;

		switch (typeNum)
		{
		case Unit.Type.Infantry:
			return CalculateInfantryValue (_infantryLevel, INFANTRY_BASE_COST);
		case Unit.Type.APU:
			return CalculateValue (_APUlevel, APU_BASE_COST);
		case Unit.Type.Morpheus:
			return CalculateValue (_morpheusLevel, MORPHEUS_BASE_COST);
		case Unit.Type.Trinity:
			return CalculateValue (_trinityLevel, TRINITY_BASE_COST);
		case Unit.Type.Oracle:
			return CalculateValue (_oracleLevel, ORACLE_BASE_COST);
		case Unit.Type.Neo:
			return CalculateValue (_neoLevel, NEO_BASE_COST);
		default:
			return 0;
		}
	}

	int CalculateInfantryValue(int level, int cost)
	{
		float baseValue = (1 + level) * cost;
		baseValue = Mathf.Pow(baseValue, 1 + (UPGRADE_POWER_INFANTRY_MULTIPLIER * level));
		return (int)baseValue;
	}

	int CalculateValue(int level, int cost)
	{
		float baseValue = (1 + level) * cost;
		baseValue = Mathf.Pow(baseValue, 1 + (UPGRADE_POWER_MULTIPLIER * level));
		return (int)baseValue;
	}

    public void HandleShopButton(int buttonNumber)
    {
		Unit.Type typeNum = (Unit.Type) buttonNumber;
		_UpgradeUnit (typeNum);

		upgradeButtonTexts [buttonNumber].text = GetButtonText (buttonNumber);
		upgradeDescriptionTexts [buttonNumber].text = GetDescriptionText (buttonNumber);

		if (buttonNumber == 5 && GetUnitLevel(typeNum) == 2)
		{
			upgradeDescriptionTexts [buttonNumber].text = "Upgrade Neo one more time to win the game!\n"+ NUM + GetUnitLevel (typeNum);
		}
		if (buttonNumber == 5 && GetUnitLevel(typeNum) == 3)
		{
			Application.Quit ();
		}
    }

    void _UpgradeUnit(Unit.Type type)
    {
        int money = MoneyManager.Instance.GetMoney();
        
		int currentCost = GetUnitCost((int) type);
        if (money >= currentCost)
        {  
			MoneyManager.Instance.SubtractMoney(currentCost);
            switch (type)
            {
                case Unit.Type.Infantry:
                    if (_infantryLevel < 5)
                    {
                        _infantryLevel++;
                        PreferencesManager.Instance.SetValue("InfantryLevel", _infantryLevel);
                        GameManager.Instance.GetInfantryUnits()[_infantryLevel - 1].Show();
                    }
                    break;
                case Unit.Type.APU:
                    _APUlevel++;
                    PreferencesManager.Instance.SetValue("APULevel", _APUlevel);
                    GameManager.Instance.GetUnit(type).Upgrade(_APUlevel);
                    break;
                case Unit.Type.Morpheus:
                    _morpheusLevel++;
                    PreferencesManager.Instance.SetValue("MorpheusLevel", _morpheusLevel);
                    GameManager.Instance.GetUnit(type).Upgrade(_morpheusLevel);
                    break;
                case Unit.Type.Trinity:
                    _trinityLevel++;
                    PreferencesManager.Instance.SetValue("TrinityLevel", _trinityLevel);
                    GameManager.Instance.GetUnit(type).Upgrade(_trinityLevel);
                    break;
                case Unit.Type.Oracle:
                    _oracleLevel++;
                    PreferencesManager.Instance.SetValue("OracleLevel", _oracleLevel);
                    GameManager.Instance.GetUnit(type).Upgrade(_oracleLevel);
                    break;
                case Unit.Type.Neo:
                    _neoLevel++;
                    PreferencesManager.Instance.SetValue("NeoLevel", _neoLevel);
                    GameManager.Instance.GetUnit(type).Upgrade(_neoLevel);
                    break;
            }
        }else
        {
            MoneyManager.Instance.notEnougFundsText(type.ToString());
        }
    }

    public int GetUnitLevel(Unit.Type unitType)
    {
        switch (unitType)
        {
            case Unit.Type.Infantry:
                return _infantryLevel;
            case Unit.Type.APU:
                return _APUlevel;
            case Unit.Type.Morpheus:
                return _morpheusLevel;
            case Unit.Type.Trinity:
                return _trinityLevel;
            case Unit.Type.Oracle:
                return _oracleLevel;
            case Unit.Type.Neo:
                return _neoLevel;
            default:
                return 0;
        }
    }
}
