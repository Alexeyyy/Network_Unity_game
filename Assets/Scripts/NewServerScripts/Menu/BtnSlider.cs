using UnityEngine;
using System.Collections;

public class BtnSlider : MonoBehaviour {

	public int delta;
	public Camera camera; 

	private void OnMouseDown() {
		camera.GetComponent<MenuSlider>().currentElement += delta;
	}
}
