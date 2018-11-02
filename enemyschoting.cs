using UnityEngine;
using System.Collections;

public class enemyschoting : MonoBehaviour {
	


	float snelheid = 20;
	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {
		
		transform.Translate (0, -1 * snelheid * Time.deltaTime, 0);

		if (transform.position.y < -10f) {
			Destroy (gameObject);
		}



	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.transform.name == "Cube") {
			
			Destroy (gameObject);
		}

	}
}
