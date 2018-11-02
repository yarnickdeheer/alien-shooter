using UnityEngine;
using System.Collections;

public class positie : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1);
	
	}
}
