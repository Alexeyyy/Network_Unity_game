using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	public int health = 100;

	void Update () {
		if(networkView.isMine)
		{
			float translation = Input.GetAxis("Vertical") * speed;
			float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(0, translation, 0);
			transform.Rotate(0,0,rotation);

			if( health <=0)
			{
				Network.Destroy(gameObject);
				//GameObject.Destroy(gameObject);
			}
		}
	}
	private void OnCollisionEnter(Collision c)
	{
		/*if(networkView.isMine)
			health -= 25;*/
	}
}
