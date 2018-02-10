using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
	void Start ()
	{
		// Initialize other managers
		Application.targetFrameRate = 60;
		PreferencesManager.Instance.Init ();
		ViewManager.Instance.Init ();
		GameManager.Instance.Init ();
        ShopManager.Instance.Init();
        MoneyManager.Instance.Init();
	}
}