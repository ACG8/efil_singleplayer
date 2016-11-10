using UnityEngine;
using System.Collections;

//When activated, causes the cell to move forward (in the relative up direction)
public class MoveForward : MonoBehaviour {

	public int force_multiplier = 1;
	bool active = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
			this.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * force_multiplier);
	}

	public void Toggle_Active() {
		active = !active;
	}
}
