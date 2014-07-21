using UnityEngine;
using System.Collections;

public class BtnLoadScene : MonoBehaviour {
	public string sceneName;

	public void OnMouseDown() {
		BtnGoTo.isLevelChoice = false;
		BtnGoTo.isAuthors = false;
		Application.LoadLevel(sceneName);
	}
}
