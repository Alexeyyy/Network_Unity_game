using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	public int damage = 20;
	public bool isEnemyShot = false;
	public float lifeBulletTime = 1;

	// Use this for initialization
	private void Start () {
		Destroy (this.gameObject, lifeBulletTime);
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
}
