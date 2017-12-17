using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed=10;
	public float _jump=500;

	Vector3 move;
	Rigidbody2D rig;
	int flg_jump = 1;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//move = Vector3.up * flg_jump * Input.GetAxis("Vertical") * _jump;
		move = Vector3.right * Input.GetAxis("Horizontal") * speed;
		rig.AddForce (move);
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			rig.AddForce (new Vector3(0,flg_jump * _jump,0));
		}
		//if(Input.GetAxis("Vertical")>0)flg_jump = 0;
		Debug.Log (flg_jump);
	}
	void OnCollisionEnter2D(Collision2D col){
		flg_jump = 1;
	}
	void OnCollisionExit2D(Collision2D col){
		flg_jump = 0;
	}
}