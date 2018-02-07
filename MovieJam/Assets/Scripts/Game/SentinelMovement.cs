using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelMovement : MonoBehaviour {

	const float MOVESPEED = 0.01f;
	const float SINE_MULTIPLIER = 0.4f;
	const float HEAD_ROTATION_MULTIPLIER = 0.15f;

	Vector3 startPosition;
	Quaternion startRotation;

	float x;
	float y;
	float z_rot;
	float rot_timer;

	void Start () {
		rot_timer = 0;
		startPosition = transform.position;
		startRotation = transform.rotation;
	}

	void Update () {
		rot_timer += Time.deltaTime;
		// horizontal Sine movement:
		x = Mathf.Sin(rot_timer) * SINE_MULTIPLIER;

		// Head rotation
		z_rot = Mathf.Cos(rot_timer - 0.25f) * HEAD_ROTATION_MULTIPLIER;
		transform.rotation = new Quaternion (0f, 0f, z_rot, 1f);

		// Moving down
		y -= MOVESPEED;

		transform.position = startPosition + new Vector3(x, y, 0f);
	}
}
