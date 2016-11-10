using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellNeighborManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Initialize joints. In order, [up, lt, dn, rt]
		for (int i=0; i<4; i++)
			transform.gameObject.AddComponent<FixedJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LinkJointToNeighbor ( FixedJoint2D joint, GameObject neighbor ) {
		Debug.Log("From " + joint.transform.gameObject + " to " + neighbor);
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
			LinkJointToNeighbor (transform.GetComponents<FixedJoint2D> ()[3], GetNeighborAtPosition (rt_pos));
		if (GetNeighborAtPosition (lt_pos) != null)
			LinkJointToNeighbor (transform.GetComponents<FixedJoint2D> ()[1], GetNeighborAtPosition (lt_pos));
		if (GetNeighborAtPosition (up_pos) != null)
			LinkJointToNeighbor (transform.GetComponents<FixedJoint2D> ()[0], GetNeighborAtPosition (up_pos));
		if (GetNeighborAtPosition (dn_pos) != null) {
			LinkJointToNeighbor (transform.GetComponents<FixedJoint2D> ()[2], GetNeighborAtPosition (dn_pos));
		}
	}


}
