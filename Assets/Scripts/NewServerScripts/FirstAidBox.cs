using UnityEngine;
using System.Collections;

public class FirstAidBox : MonoBehaviour {
	public int HP_amount;

	private void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "SpaceShip") {
			collider.GetComponent<PlayerScript>().HP += HP_amount;
			Destroy(this.gameObject);
		}
	}
}
