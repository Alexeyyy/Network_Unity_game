using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int hp = 2;
	public bool isEnemy = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collider) {
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();


		if(shot != null) {
			hp -= shot.damage;
			Destroy(shot.gameObject);
			if(hp <= 0) {
				Destroy(this.gameObject);
			}
		}

		/*ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		if(shot != null) {
			if(shot.isEnemyShot != isEnemy) {
				hp -= shot.damage;
				Destroy(shot.gameObject);
				Debug.Log ("Inside");
				if(hp <= 0) {
					Destroy(this.gameObject);
				}
			}
		}*/
	}
}
