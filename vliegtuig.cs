using UnityEngine;
using System.Collections;

public class vliegtuig : MonoBehaviour {
	float xPos = 0;
	float yPos = 0;
	public float snelheid = 10;
	public float rotsnelheid = 100;
	// Use this for initialization
	void Start () {
		transform.position = (new Vector3 (xPos, yPos, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x + Input.GetAxis ("hor") * snelheid * Time.deltaTime < 360 && transform.rotation.x + Input.GetAxis ("hor") * snelheid * Time.deltaTime > -360	) {
			transform.Rotate (0, 0, Input.GetAxis ("hor") * rotsnelheid * Time.deltaTime );


		}
		if (transform.position.y + Input.GetAxis ("ver") * snelheid * Time.deltaTime < 4.5 && transform.position.y + Input.GetAxis ("ver") * snelheid * Time.deltaTime > -4.5) { 
			transform.Translate (0, Input.GetAxis ("ver") * snelheid * Time.deltaTime, 0);

}

}
}