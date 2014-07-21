using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour {
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

	private void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "Bullet") {
			int probability = Random.Range(0,150);
			Quaternion direction;
			Debug.Log (probability);
			if(probability <= 25) {
				direction = new Quaternion(0,0,-45,0);
				collider.gameObject.transform.rotation = this.transform.rotation * direction;
			}
			if(probability > 25 && probability <= 50) {
				direction = new Quaternion(0,0,45,0);
				collider.gameObject.transform.rotation = this.transform.rotation * direction;
			}

			if(probability > 50 && probability <= 75) {
				direction = new Quaternion(0,0,135,0);
				collider.gameObject.transform.rotation = this.transform.rotation * direction;
			}

			if(probability > 75 && probability <= 100) {
				direction = this.transform.rotation;
				collider.gameObject.transform.rotation = this.transform.rotation * direction;
			}
			if(probability > 100) {
				collider.gameObject.transform.rotation = this.transform.rotation;
			}
		}

		if(collider.gameObject.tag == "SpaceShip") {
			collider.gameObject.GetComponent<PlayerScript>().IsKilled = true;
		}
	}
}
