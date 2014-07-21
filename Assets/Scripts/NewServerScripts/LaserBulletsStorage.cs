using UnityEngine;
using System.Collections;

public class LaserBulletsStorage : MonoBehaviour {
	public int Bullets_amount;
	
	private void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "SpaceShip") {
			collider.GetComponent<PlayerScript>().bulletsStorage += Bullets_amount;
			Destroy(this.gameObject);
		}
	}
}
