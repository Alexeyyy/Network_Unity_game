using UnityEngine;
using System.Collections;

public class BtnGoTo : MonoBehaviour {
	public Camera camera;
	public Vector3 position;
	public static bool isLevelChoice = false;
	public static bool isMainMenu;
	public static bool isAuthors = false;

	private void OnMouseDown() {
		if(this.tag == "ChoiceLevelMenu") {
			isLevelChoice = true;
			isAuthors = false;
		}
		if(this.tag == "MainMenu") {
			isLevelChoice = false;
			isAuthors = false;
		}
		if(this.tag == "Authors") {
			isLevelChoice = false; //for emergency occasion
			isAuthors = true;
		}
		camera.transform.position = position;
	}
}
