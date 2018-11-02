using UnityEngine;
using System.Collections;

public class bosqui : MonoBehaviour {
	public GUISkin bos;
	public int hp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.name == "kogel(Clone)") {
			hp--;
		}
	}
	void OnGUI (){
		GUI.skin = bos;
		GUI.Label (new Rect (10, 10, 675, 2350), "bos hp: " + hp);
	}
}
