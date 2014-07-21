using UnityEngine;
using System.Collections;

public class GalaxyScript : MonoBehaviour {
	public float rotationSpeed;
	public int direction;
	
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		float rotation = rotationSpeed * Time.deltaTime;
		this.transform.Rotate(0, 0, rotationSpeed * direction); 
	}

}
