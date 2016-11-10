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

	public GameObject CreateNewCell (Vector2 localOffset) {
		Vector2 worldOffset = transform.rotation * localOffset;
		Vector2 worldPosition = new Vector2 (transform.position.x, transform.position.y) + worldOffset;
		GameObject newcell = Instantiate (cell, worldPosition, transform.rotation) as GameObject;

		if (newcell != null) {
			newcell.GetComponent<CellNeighborManager> ().LinkJointsToNeighbors ();
			transform.GetComponent<CellNeighborManager> ().LinkJointToNeighbor (newcell);
		}
		return newcell;
	}
}
