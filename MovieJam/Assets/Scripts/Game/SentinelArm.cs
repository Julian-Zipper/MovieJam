using UnityEngine;

public class SentinelArm : MonoBehaviour {

	const string ARM_PART_PREFAB_LOCATION = "Sentinel/arm_part";
	const int NUMBER_OF_ARM_PARTS = 7;
	const float ARM_PART_HEIGHT = 0.18f;

	Rigidbody2D hook;
	GameObject armPart;

	void Start () {
		armPart = Resources.Load<GameObject> (ARM_PART_PREFAB_LOCATION);
		hook = transform.GetChild (0).GetComponent<Rigidbody2D>();	// hook is always the first element of an arm object in the hierarchy.
		GenerateArm ();
	}

	void GenerateArm()
	{
		
		Rigidbody2D previousRigidBody = hook;	// Default previous part is the first part of the arm, which is always the hook.

		for (int i = 0; i < NUMBER_OF_ARM_PARTS; i++) {
			GameObject currentPart = GameObject.Instantiate (armPart);
			currentPart.transform.position = new Vector2 (transform.position.x, transform.position.y - ARM_PART_HEIGHT);
			HingeJoint2D joint = currentPart.GetComponent<HingeJoint2D> ();
			joint.connectedBody = previousRigidBody;

			previousRigidBody = currentPart.GetComponent<Rigidbody2D> ();	// set the correct (current) rigidbody for the next arm part to link to.
		}
	}
}
