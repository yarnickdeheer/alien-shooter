using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class vliegtuiglvl2 : MonoBehaviour {
	Vector3 beginPositie;	
	float xPos = 0;
	public GUISkin tekstSkin;
	levelManagement levelmanager;
	score punten;

		float yPos = 0;
		public float snelheid = 10;
		public float rotsnelheid = 100;
public static int aantal_spelers;
	public int hp;
		float volgendSchot = 0.5f;
	public float padding;
		float vuurRate = 0.2f; 
	float stuur;
	float xmin;
	float xmax;

	public Transform schietObj;
		// Use this for initialization
		void Start () {
		punten = GameObject.FindObjectOfType<score> ();
		levelmanager = GameObject.FindObjectOfType<levelManagement> ();
		beginPositie = transform.position;
		aantal_spelers++;
		enemy enemy = GameObject.FindObjectOfType<enemy> ();
		enemy.aantal_enemys = 0;

		print ( "kerel" + aantal_spelers);
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 meestlinks = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 meestrechts = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = meestlinks.x + padding;
		xmax = meestrechts.x - padding;
		}


		// Update is called once per frame
		void Update () {
		stuur = Mathf.Clamp ((stuur += (Input.GetAxis ("hor") * Time.deltaTime * snelheid )) , xmin, xmax);
		transform.position = new Vector2 (stuur, transform.position.y);
		
		if (hp < 1) {
			Destroy (this.gameObject);
			score.punten=enemy.punten;
			aantal_spelers--;
			EmuleerLose ();
		}
	if (aantal_spelers < 1) {
			EmuleerLose ();
		}
		if (transform.position.x + Input.GetAxis ("hor") * snelheid * Time.deltaTime < 6 && transform.position.x + Input.GetAxis ("hor") * snelheid * Time.deltaTime > -6) {
			transform.Translate (Input.GetAxis ("hor") * snelheid * Time.deltaTime, 0, 0);


		}
		if (Input.GetAxis ("schot") == 1) {
			if (Time.time >= volgendSchot) {
			
				Instantiate (schietObj, new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
				volgendSchot = Time.time + vuurRate;
			}







			// else {
			//	print ("");
			//}

			//if (transform.position.y + Input.GetAxis ("ver") * snelheid * Time.deltaTime < 4.5 && transform.position.y + Input.GetAxis ("ver") * snelheid * Time.deltaTime > -4.5) { 
			//	transform.Translate (0, Input.GetAxis ("ver") * snelheid * Time.deltaTime, 0);

			//}

		}
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.name == "enemykogel(Clone)") {
			hp--;
	}
	}
	void EmuleerLose(){
		SceneManager.LoadScene("verloren");
	}
	void OnGUI ()
	{
		GUI.skin = tekstSkin;
		GUI.Label (new Rect (10, 10, 300, 1200	), "hp: " + hp);
	}


	}
	
