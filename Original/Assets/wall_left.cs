using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_left : MonoBehaviour {
	public GameObject a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		a.GetComponent<PlayerController> ().change_flg (0,false);
	}
	void OnTriggerExit2D(Collider2D col){
		a.GetComponent<PlayerController> ().change_flg (1,false);
	}
}
