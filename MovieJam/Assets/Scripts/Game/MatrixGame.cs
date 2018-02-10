using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGame : MonoBehaviour
{
	const float SENTINEL_SPAWN_HEIGHT = 6.25f;
	const float SENTINEL_SPAWN_MIN_X = -8f;
	const float SENTINEL_SPAWN_MAX_X = 1f;

	const float UNIT_SPAWN_MIN_X = -8f;
	const float UNIT_SPAWN_MAX_X = 1f;
	const float UNIT_SPAWN_HEIGHT = -2.5f;

	const float SENTINEL_STARTING_SPAWN_TRESHOLD = 3f;

	List<GameObject> sentinels;
	List<GameObject> apus;
	List<GameObject> infantry;

    bool _spawning;
	float _spawnTimer;
	float _spawnTreshold;

	// Use this for initialization
	public void Init ()
	{
		sentinels = new List<GameObject> ();
		apus = new List<GameObject> ();
		infantry = new List<GameObject> ();

		Reset ();
		// TEST CODE
		Invoke ("SpawnInfantry", 2f);
		Invoke ("SpawnInfantry", 4f);
	}

	public void Reset()
	{
		_spawning = false;
		_spawnTimer = 0f;
		_spawnTreshold = SENTINEL_STARTING_SPAWN_TRESHOLD;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_spawning)
		{
			if (_spawnTimer > _spawnTreshold) 
			{
				SpawnSentinel ();
				_spawnTimer = 0f;
			}
		}

		_spawnTimer += Time.fixedDeltaTime;
	}

	public void SetSpawning(bool value)
	{
		_spawning = value;
	}

	void SpawnSentinel()
	{
		GameObject newSentinel = GameObject.Instantiate (Resources.Load<GameObject> ("Sentinel/Sentinel"));
		newSentinel.transform.position = new Vector3 (Random.Range(SENTINEL_SPAWN_MIN_X, SENTINEL_SPAWN_MAX_X), SENTINEL_SPAWN_HEIGHT, 0);
		newSentinel.tag = "Sentinel";
		sentinels.Add (newSentinel);
	}

	void SpawnInfantry()
	{
		GameObject newInfantry = GameObject.Instantiate (Resources.Load<GameObject> ("Units/Infantry"));
		// TODO: instead of giving infantry a random position, give them a set position.
		newInfantry.transform.position = new Vector3 (Random.Range(UNIT_SPAWN_MIN_X, UNIT_SPAWN_MAX_X), UNIT_SPAWN_HEIGHT, 0);
		infantry.Add (newInfantry);
	}

	public void HandleShootClick()
	{
		foreach (GameObject unit in infantry) {
			if (sentinels.Count > 0)
			{
				GameObject target = sentinels [0];
				unit.GetComponent<Unit> ().AcquireTarget(target);
				unit.GetComponent<Unit> ().Fire ();
				Destroy (target, 0.5f);
				sentinels.RemoveAt (0);
                MoneyManager.Instance.money = MoneyManager.Instance.getMoney() + 5;
                MoneyManager.Instance.setMoney(MoneyManager.Instance.money);
                MoneyManager.Instance.updateMoneyText();
            }
		}
	}
}
