using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	// Use this for initialization
	public void Init ()
	{
		
	}

	public void Reset()
	{

	}

	public void HandleStartButton()
	{
		GameManager.Instance.StartGame ();
	}
}
