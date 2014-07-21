using UnityEngine;
using System.Collections;

public class StarWarsText : MonoBehaviour {
	public Vector3 animationStartPosition;
	public Vector3 animationEndPosition;
	public float speed;
	public GameObject text;
		
	private void Update () {
		if(BtnGoTo.isAuthors) {
			this.transform.position = Vector3.Lerp (this.transform.position, animationEndPosition, Time.deltaTime * speed);
			Debug.Log ("1");
		}
		if(!BtnGoTo.isAuthors) {
			text.transform.position = animationStartPosition;
			Debug.Log ("2");
		}
	}
}
