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

		tabOffense = transform.Find ("UpgradesBG/TabButtonContainer/Tab1Button").gameObject;
		tabDefense = transform.Find ("UpgradesBG/TabButtonContainer/Tab2Button").gameObject;
		tab3 = transform.Find ("UpgradesBG/TabButtonContainer/Tab3Button").gameObject;

		containerOffense = transform.Find ("UpgradesBG/OffenseUpgrades").gameObject;
		containerDefense = transform.Find ("UpgradesBG/DefenseUpgrades").gameObject;
		container3 = transform.Find ("UpgradesBG/Upgrades_3").gameObject;
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
}
