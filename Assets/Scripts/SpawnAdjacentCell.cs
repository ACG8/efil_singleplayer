using UnityEngine;
using System.Collections;

public class SpawnAdjacentCell : MonoBehaviour {

	public GameObject cell;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public GameObject CreateNewCell ( GameObject creator ) {
		Vector2 localOffset = new Vector2 (0.5f, 0f);
		Vector2 worldOffset = creator.transform.rotation * localOffset;
		Vector2 worldPosition = new Vector2 (creator.transform.position.x, creator.transform.position.y) + worldOffset;
		GameObject newcell = Instantiate (cell, worldPosition, creator.transform.rotation) as GameObject;
		//now connect with joints
		FixedJoint2D creatorjoint = transform.parent.gameObject.AddComponent<FixedJoint2D> ();
		creatorjoint.connectedBody = newcell.GetComponent<Rigidbody2D> ();

		FixedJoint2D newcelljoint = newcell.transform.FindChild("dnJoint").gameObject.AddComponent<FixedJoint2D> ();
		newcelljoint.connectedBody = creator.GetComponent<Rigidbody2D> ();

		return newcell;
	}
}
