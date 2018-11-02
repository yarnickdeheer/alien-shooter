using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {
	public GameObject enemy;
	enemyspawner enemySpawner;
	public GameObject enemypref;
	bool rechtsbewegen = true;
	public float snelheid = 5f;
	public float width = 15f;
	float xmin;
	float xmax;
	public float padding = 1.5f;

		void SpawnEnemies(){
			foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemypref, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child; 
	}
	}
		void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 meestlinks = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		Vector3 meestrechts = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		xmin = meestlinks.x + padding;
		xmax = meestrechts.x - padding;
		
		SpawnEnemies ();
	}
		
		void Update () {
		enemy enemy = GameObject.FindObjectOfType<enemy> ();
		if (rechtsbewegen) {
			transform.position += Vector3.right * snelheid * Time.deltaTime;
		} else {
			transform.position += Vector3.left * snelheid * Time.deltaTime;
		}
		float rechterGrens = transform.position.x + (0.5f * width);
		float linkerGrens = transform.position.x - (-0.4f * width);
		if (linkerGrens < xmin){
			rechtsbewegen = true;
		} else if (rechterGrens > xmax){
			rechtsbewegen = false;
		}
		if (AlleEnemiesDood ()) {
			SpawnTotVol ();

		}
	}
		void SpawnTotVol(){
		Transform freePosition = VolgendeFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemypref, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (VolgendeFreePosition ()){
			Invoke ("SpawnTotVol", 2f);
		}
	}


	Transform VolgendeFreePosition(){
			foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0 ){
				return childPositionGameObject;
			}

		}
			return null;
	}


	bool AlleEnemiesDood(){
			foreach (Transform childPositionGameObject in transform ){
			if (childPositionGameObject.childCount >0){
				return false;
				
			}
		}
			return true;
	}
		



	void OnDrawGizmos(){
			Gizmos.DrawWireCube (transform.position, new Vector2 (10f, 10f));

		}
	}

	
