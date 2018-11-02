using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class score : MonoBehaviour {
	public static int punten;
	static score instance = null;


	public GUISkin scorepunten;
	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}


	}

	// Update is called once per frame
	void Update () {

	}
		void OnGUI (){
		
		GUI.skin = scorepunten;
		GUI.Label (new Rect (250, 500, 675, 2350), "punten  : " + punten);
	}
}