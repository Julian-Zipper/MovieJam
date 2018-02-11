using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	GameObject tabOffense, tabDefense, tab3;
	GameObject containerOffense, containerDefense, container3;

	Sprite[] _tabSprites;

	void Start () {
		_tabSprites = Resources.LoadAll<Sprite> ("Spritesheets/Tab");

		tabOffense = transform.Find ("Upgrades/TabButtonContainer/Tab1Button").gameObject;
		tabDefense = transform.Find ("Upgrades/TabButtonContainer/Tab2Button").gameObject;
		tab3 = transform.Find ("Upgrades/TabButtonContainer/Tab3Button").gameObject;

		containerOffense = transform.Find ("Upgrades/OffenseUpgrades").gameObject;
		containerDefense = transform.Find ("Upgrades/DefenseUpgrades").gameObject;
		container3 = transform.Find ("Upgrades/Upgrades_3").gameObject;

		ShopManager.Instance.SetupButtons ();
	}

	public void HandleTab1Click()
	{
		tabOffense.GetComponent<Image> ().sprite = _tabSprites [1];
		containerOffense.SetActive (true);

		tabDefense.GetComponent<Image> ().sprite = _tabSprites [0];
		containerDefense.SetActive (false);
		tab3.GetComponent<Image> ().sprite = _tabSprites [0];
		container3.SetActive (false);
	}

	public void HandleTab2Click()
	{
		tabDefense.GetComponent<Image> ().sprite = _tabSprites [1];
		containerDefense.SetActive (true);

		tabOffense.GetComponent<Image> ().sprite = _tabSprites [0];
		containerOffense.SetActive (false);
		tab3.GetComponent<Image> ().sprite = _tabSprites [0];
		container3.SetActive (false);
	}

	public void HandleTab3Click()
	{
		tab3.GetComponent<Image> ().sprite = _tabSprites [1];
		container3.SetActive (true);

		tabOffense.GetComponent<Image> ().sprite = _tabSprites [0];
		containerOffense.SetActive (false);
		tabDefense.GetComponent<Image> ().sprite = _tabSprites [0];
		containerDefense.SetActive (false);
	}

	public void HandleUpgradeClick(int buttonNumber)
	{
		switch (buttonNumber) {
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
			break;
		case 13:
			break;
		case 14:
			break;
		case 15:
			break;
		case 16:
			break;
		case 17:
			break;
		}
	}
}
