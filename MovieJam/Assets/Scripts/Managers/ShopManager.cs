using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager> {

    //Offense
    int _infantryLevel;
    int _APUlevel;
    int _morpheusLevel;
    int _trinityLevel;
    int _oracleLevel;
    int _neoLevel;

    public override void Init()
    {
        _infantryLevel = PreferencesManager.Instance.Get("InfantryLevel");
        _APUlevel = PreferencesManager.Instance.Get("APULevel");
        _morpheusLevel = PreferencesManager.Instance.Get("MorpheusLevel");
        _trinityLevel = PreferencesManager.Instance.Get("TrinityLevel");
        _oracleLevel = PreferencesManager.Instance.Get("OracleLevel");
        _neoLevel = PreferencesManager.Instance.Get("NeoLevel");
    }

    public void HandleShopButton(int buttonNumber)
    {
        switch (buttonNumber)
        {
            //TODO: Check if there's enough money before upgrading. If not, show feedback?
            case 0:
                //Example:
                //if(MoneyManager.Instance.UnitAvailable(Unit.Type.Infantry))
                _UpgradeUnit(Unit.Type.Infantry);
                //else
                //FeedbackManager.Instance.ShowNotEnoughMoneyFeedback();
                break;
            case 1:
                _UpgradeUnit(Unit.Type.APU);
                break;
            case 2:
                _UpgradeUnit(Unit.Type.Morpheus);
                break;
            case 3:
                _UpgradeUnit(Unit.Type.Trinity);
                break;
            case 4:
                _UpgradeUnit(Unit.Type.Oracle);
                break;
            case 5:
                _UpgradeUnit(Unit.Type.Neo);
                break;
        }
    }

    void _UpgradeUnit(Unit.Type type)
    {
        switch (type)
        {
            case Unit.Type.Infantry:
                //TODO: Add and activate another infantry unit
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
