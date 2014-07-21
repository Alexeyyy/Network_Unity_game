using UnityEngine;
using System.Collections;

public class MenuSlider : MonoBehaviour {

	public Camera camera;
	public float speed;
	public int currentElement;
	public GameObject[] menuItems;
	public Vector3 normalSize;
	public GameObject leftBtn;
	public GameObject rightBtn;

	// Use this for initialization
	private void Start () {
		//camera.transform.position = new Vector3(menuItems[currentElement].transform.position.x, 0, camera.transform.position.z);
		currentElement = menuItems.Length/2;
	}

	private void LocateCamera(Camera _camera, float _speed) {
		if(currentElement == menuItems.Length) {
			currentElement--;
		}
		if(currentElement < 0) {
			currentElement++;
		}

		Vector3 endPos = new Vector3(menuItems[currentElement].transform.position.x, 0, _camera.transform.position.z);
		_camera.transform.position = Vector3.Lerp(_camera.transform.position, endPos, Time.deltaTime * _speed);
	}

	// Update is called once per frame
	private void Update () {
		if(BtnGoTo.isLevelChoice) {
			leftBtn.renderer.enabled = true;
			rightBtn.renderer.enabled = true;
			LocateCamera(camera, speed);
		}
		else {
			leftBtn.renderer.enabled = false;
			rightBtn.renderer.enabled = false;
			currentElement = menuItems.Length/2;
		}
	}
}
