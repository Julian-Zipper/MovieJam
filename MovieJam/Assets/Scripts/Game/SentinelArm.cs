using UnityEngine;

public class SentinelArm : MonoBehaviour {

	const string ARM_PART_PREFAB_LOCATION = "Sentinel/arm_part";
	const string ARM_CLAW_PREFAB_LOCATION = "Sentinel/arm_claw";
	const string ARM_END_PREFAB_LOCATION = "Sentinel/arm_end_joint";

	const float ARM_PART_HEIGHT = 0.18f;
	const float ARM_CLAW_HEIGHT = 0.36f;

	const int NUMBER_OF_ARM_PARTS = 8;

	Rigidbody2D hook;

	void Start ()
	{
		hook = transform.GetChild (0).GetComponent<Rigidbody2D>();	// hook is always the first element of an arm object in the hierarchy.
		GenerateArm ();
	}

	void GenerateArm()
	{
		GameObject armPart = Resources.Load<GameObject> (ARM_PART_PREFAB_LOCATION);
		GameObject clawPart	= Resources.Load<GameObject> (ARM_CLAW_PREFAB_LOCATION);
		GameObject endJointPart	= Resources.Load<GameObject> (ARM_END_PREFAB_LOCATION);

		Rigidbody2D previousRigidBody = hook;	// Default previous part is the first part of the arm, which is always the hook.

		for (int i = 0; i < NUMBER_OF_ARM_PARTS; i++) 
		{
			GameObject currentPart;

			if (i == NUMBER_OF_ARM_PARTS - 2)
			{
				currentPart = GameObject.Instantiate (clawPart);
				currentPart.transform.position = new Vector2 (transform.position.x, transform.position.y - ARM_CLAW_HEIGHT);
			}
			else if (i == NUMBER_OF_ARM_PARTS - 1) 
			{	
				currentPart = GameObject.Instantiate (endJointPart);
				currentPart.transform.position = new Vector2 (transform.position.x, transform.position.y - ARM_CLAW_HEIGHT);
			}
			else
			{
				currentPart = GameObject.Instantiate (armPart);
				currentPart.transform.position = new Vector2 (transform.position.x, transform.position.y - ARM_PART_HEIGHT);
			}

			currentPart.transform.parent = this.transform;
			HingeJoint2D joint = currentPart.GetComponent<HingeJoint2D> ();
			joint.connectedBody = previousRigidBody;

			previousRigidBody = currentPart.GetComponent<Rigidbody2D> ();	// set the correct (current) rigidbody for the next arm part to link to.
		}
	}
}
