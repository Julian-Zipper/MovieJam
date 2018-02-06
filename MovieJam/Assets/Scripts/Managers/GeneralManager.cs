using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
	void Start ()
	{
		// Initialize other managers
		Application.targetFrameRate = 40;
		PreferencesManager.Instance.Init();
		GameManager.Instance.Init();
	}
}