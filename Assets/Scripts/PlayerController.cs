using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject cell;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject target = ClickSelect ();
			//take behavior based on scripts
			if (target != null) {
				target.GetComponent<MoveForward> ().Toggle_Active ();
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			GameObject target = ClickSelect ();
			//take behavior based on scripts
			if (target != null) {
				Debug.Log ("hit");
				Debug.Log (target);
				// for nubs
				SpawnAdjacentCell spawnscript = target.GetComponent<SpawnAdjacentCell>();
				if (spawnscript != null) {
					Debug.Log ("spawn");
					spawnscript.CreateNewCell (target);
				}
			}
		}
	}

	GameObject ClickSelect() {
		Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);

		if (hit) {
			//figure out which part of the cell was hit

			return hit.collider.transform.gameObject;
		}
		else
			return null;
	}
}
