using UnityEngine;
using System.Collections;

public class bos : MonoBehaviour {

	Vector3 beginPositie;
	float xPos = 0;
	float yPos = 0;
	public float snelheid = 10;
	private int schiet;
	public int hp;
	public static int aantal_enemys;
	public Transform schietObj;
	float max ;
	float min;

	// Use this for initialization
	void Start () {
		beginPositie = transform.position;
		min = transform.position.x;
		max = transform.position.x + 5.5f;
		aantal_enemys++;
		print (aantal_enemys);
	}


	// Update is called once per frame
	void Update () {
		if (hp < 1) {
			Destroy (this.gameObject);
			aantal_enemys--;

		}
		if (aantal_enemys < 1) {
			EmuleerWin ();
		}

		transform.position = new Vector3 (Mathf.PingPong (Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
		schiet = Random.Range (1, 100);


		if (schiet == 21 ) {
			Instantiate (schietObj, new Vector3 (transform.position.x, transform.position.y - 2f, 0), Quaternion.identity);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.name == "kogel(Clone)") {
			hp--;
			//Destroy (bots.gameObject);
		}
	}
	void EmuleerWin(){
		levelManagement.LaadVolgende();
	}
}




