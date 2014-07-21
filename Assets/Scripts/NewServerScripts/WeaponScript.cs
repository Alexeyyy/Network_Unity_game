using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public GameObject shotPrefab;
	public GameObject spawnPoint1;
	public GameObject spawnPoint2;
	public GameObject player;

	public float reloadingTime = 0.25f;
	private float shotCoolDown;
	public bool CanShot {get { return shotCoolDown <= 0; } }

	// Use this for initialization
	private void Start () {
		shotCoolDown = 0;
	}
	
	// Update is called once per frame
	private void Update () {
		if(shotCoolDown > 0) {
			shotCoolDown -= Time.deltaTime;
		}
	}

	public void Attack() {
		if(CanShot) {
			shotCoolDown = reloadingTime;
			//Create a new shot
			Network.Instantiate(shotPrefab, spawnPoint1.transform.position, player.transform.rotation, 0);
			Network.Instantiate(shotPrefab, spawnPoint2.transform.position, player.transform.rotation, 0);
			player.GetComponent<PlayerScript>().bulletsStorage -= 2;
			/*shotLeftTransform.GetComponent<MoveScript>().speed = new Vector2(shotSpeed.x, shotSpeed.y);
			shotRightTransform.GetComponent<MoveScript>().speed = new Vector2(shotSpeed.x, shotSpeed.y);*/		

		}
	}
}
