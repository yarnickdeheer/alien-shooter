using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
	public class levelManagement : MonoBehaviour {

		public void LaadLevel(string levelnaam){

			SceneManager.LoadScene(levelnaam);
		}



	
		public static void LaadVolgende(){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		}

		public void StopSpel(){ 
			Application.Quit ();
		}


	}