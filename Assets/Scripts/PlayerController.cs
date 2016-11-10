using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject cell;

	private GameObject selectedCell;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			GameObject target = ClickSelect ();
			//take behavior based on scripts
			if (target != null) {
				target.GetComponent<MoveForward> ().Toggle_Active ();
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			GameObject target = ClickSelect ();
			selectedCell = target;
		}
		if (Input.GetMouseButtonUp (0) ) {
			if (selectedCell != null) {
				Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
				Vector2 displacement = mousePos - (Vector2) selectedCell.transform.position;
				if (displacement.magnitude > 0.5) {
					Vector2 unitVector = displacement / displacement.magnitude;
					Vector2 gridVector = new Vector2 (Mathf.Round (unitVector.x), Mathf.Round (unitVector.y));
					SpawnAdjacentCell spawnscript = selectedCell.GetComponent<SpawnAdjacentCell> ();
					if (spawnscript != null) {
						spawnscript.CreateNewCell (gridVector);
					}
				}
			}
			selectedCell = null;
		}
	}

	GameObject ClickSelect() {
		Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);

		if (hit)
			return hit.collider.transform.gameObject;
		else
			return null;
	}
}
