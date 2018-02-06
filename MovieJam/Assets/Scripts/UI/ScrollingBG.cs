using UnityEngine;
using System.Collections;

public class ScrollingBG : MonoBehaviour
{
	const float SCROLL_SPEED = 1f;
	const float HEIGHT = 4000f;

	RectTransform rect;
	Vector3 startPos;
	Vector3 delta;

	void Start ()
	{
		rect = this.GetComponent<RectTransform> ();
		startPos = rect.localPosition;
		delta = new Vector3 (0, -SCROLL_SPEED, 0);
	}

	void Update ()
	{
		rect.localPosition += delta;
		if (rect.localPosition.y <= -HEIGHT)
		{
			Debug.Log ("setting BG to top position");
			rect.localPosition = new Vector3 (startPos.x, HEIGHT, startPos.z);
		}
	}
}
