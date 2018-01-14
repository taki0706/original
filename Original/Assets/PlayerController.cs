using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float _jump=500;

	Rigidbody2D rig;
	int flg_jump = 1;
	float button_horizontal = 0;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Jump(){
		rig.AddForce (new Vector3(0,flg_jump * _jump,0));
	}
	public void Right_Down(){
		rig.velocity = new Vector2 (speed,0);
	}
	public void Left_Down(){
		rig.velocity = new Vector2 (-speed,0);
	}
	void OnTriggerEnter2D(Collider2D col){
		flg_jump = 1;
	}
	void OnTriggerExit2D(Collider2D col){
		flg_jump = 0;
	}
}