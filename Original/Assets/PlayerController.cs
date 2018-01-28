 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float _jump=500;
	//public GameObject body;
	public GameObject mini;
	public Tilemap field;
	public Sprite GOAL;

	Rigidbody2D rig;
	int flg_jump = 1;
	float button_horizontal = 0;
	bool flg_right=false;
	bool flg_left=false;
	int wall_right_f=1;
	int wall_left_f=1;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//Goal ();
		if(flg_right){
			Move (1.0f*wall_right_f);
		}else if(flg_left){
			Move (-1.0f*wall_left_f);
		}
	}

	//

	void Goal(){
		if(field.GetSprite(new Vector3Int((int)transform.position.x-1,(int)transform.position.y-1,(int)transform.position.z))==GOAL){
			Debug.Log ("Goal");
		}
	}
	void Move(float n){
		Vector3 direction = new Vector3 (n,0,0).normalized;
		//rig.AddForce (direction*speed);
		transform.position += direction * speed;
	}
	void OnTriggerStay2D(Collider2D col){
		Debug.Log (col.gameObject.name);
		Debug.Log ("1");
		flg_jump = 1;
	}
	void OnTriggerExit2D(Collider2D col){
		flg_jump = 0;
	}
	//

	public void Jump(){
		rig.AddForce (new Vector3(0,flg_jump * _jump,0));
	}
	public void Right_Down(){
		flg_right = true;
	}
	public void Right_Up(){
		flg_right = false;
	}
	public void Left_Down(){
		flg_left = true;
	}
	public void Left_Up(){
		flg_left = false;
	}    
	public void split(){
		transform.position += new Vector3 (0.25f,0,0);
		Vector3 v_5 = new Vector3 (0.5f,0.5f,0.5f);
		transform.localScale = v_5;
		Instantiate (mini,transform.position+new Vector3(-0.25f,0,0),Quaternion.identity);
	}
	public void change_flg(int n,bool which){
		if (which) {
			wall_right_f = n;
		} else {
			wall_left_f = n;
		}
	}
}