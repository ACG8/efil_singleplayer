using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellNeighborManager : MonoBehaviour {

	public GameObject up_joint;
	public GameObject dn_joint;
	public GameObject lt_joint;
	public GameObject rt_joint;

	// Use this for initialization
	void Start () {
		//up_joint = transform.FindChild ("upJoint").gameObject;
		//dn_joint = transform.FindChild ("dnJoint").gameObject;
		//lt_joint = transform.FindChild ("ltJoint").gameObject;
		//rt_joint = transform.FindChild ("rtJoint").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LinkJointToNeighbor ( GameObject side, GameObject neighbor ) {
		FixedJoint2D joint = side.AddComponent<FixedJoint2D> ();
		joint.connectedBody = neighbor.GetComponent<Rigidbody2D> ();
	}

	GameObject GetNeighborAtPosition(Vector2 pos) {
		Vector2 worldOffset = transform.rotation * pos;
		Vector2 worldPosition = new Vector2 (transform.position.x, transform.position.y) + worldOffset;

		RaycastHit2D hit = Physics2D.Raycast (worldPosition, Vector2.zero, 0f);

		if (hit)
			return hit.transform.gameObject;
		else
			return null;
	}

	public void LinkJointsToNeighbors () {
		Vector2 rt_pos = new Vector2 (1f, 0f);
		Vector2 lt_pos = new Vector2 (-1f, 0f);
		Vector2 up_pos = new Vector2 (0f, 1f);
		Vector2 dn_pos = new Vector2 (0f, -1f);

		if (GetNeighborAtPosition (rt_pos) != null)
			LinkJointToNeighbor (rt_joint, (GameObject) GetNeighborAtPosition (rt_pos));
		if (GetNeighborAtPosition (lt_pos) != null)
			LinkJointToNeighbor (lt_joint, (GameObject) GetNeighborAtPosition (lt_pos));
		if (GetNeighborAtPosition (up_pos) != null)
			LinkJointToNeighbor (up_joint, (GameObject) GetNeighborAtPosition (up_pos));
		if (GetNeighborAtPosition (dn_pos) != null)
			LinkJointToNeighbor (dn_joint, (GameObject) GetNeighborAtPosition (dn_pos));
	}


}
