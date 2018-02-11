using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesManager : Singleton<PreferencesManager>
{
	override public void Init()
	{
		ResetAll ();
		// SetInitialPreference("sound", true);
		// SetInitialPreference("tutorial", false);
	}

	/*
	 * True/False preference values are saved as integers, since boolean values can't be used.
	 * "0" == OFF
	 * "1" == ON
	 */
	public void SetInitialPreference(string preference, bool value)
	{
		if (!PlayerPrefs.HasKey (preference))
		{
			int preferenceNumber = System.Convert.ToInt32 (value);
			PlayerPrefs.SetInt (preference, preferenceNumber);
			PlayerPrefs.Save();
		}
	}

	public void SetInitialValue(string name, int value)
	{
		if (!PlayerPrefs.HasKey (name))
		{
			PlayerPrefs.SetInt (name, value);
			PlayerPrefs.Save();
		}
	}

	public void IncreaseValue(string name)
	{
		int newValue = PlayerPrefs.GetInt (name) + 1;
		PlayerPrefs.SetInt (name, newValue);
		PlayerPrefs.Save();
	}

	public void SetValue(string name, int value)
	{
		if (value > PlayerPrefs.GetInt(name))
		{
			PlayerPrefs.SetInt(name, value);
			PlayerPrefs.Save();
		}
	}

	public int Get(string name)
	{
		return PlayerPrefs.GetInt(name, 0);
	}

	public void ChangePlayerPreference(string preference)
	{
		PlayerPrefs.SetInt (preference, NegativeOf (PlayerPrefs.GetInt (preference)));
		PlayerPrefs.Save();
	}

	private string StringOf(int num)
	{
		if (num == 1) {
			return "ON";
		}
		return "OFF";
	}
	private int NegativeOf(int num)
	{
		if (num == 1) {
			return 0;
		}
		return 1;
	}

	public void ResetAll()
	{
		PlayerPrefs.DeleteAll ();
	}
}
