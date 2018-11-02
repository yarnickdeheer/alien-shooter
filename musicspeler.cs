using UnityEngine;
using System.Collections;

public class musicspeler : MonoBehaviour {
	static musicspeler instance = null;

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
}
