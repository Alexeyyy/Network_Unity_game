using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(50,50);
	public Vector2 rotationSpeed = new Vector2(50,50);
	public GameObject spawnPoint;
	public float HP = 100.0f;
	public Camera camera;
	public float armour;
	public int bulletsStorage;
	public float coolDownTime;

	private float HP_start;
	private Camera gameCamera;

	private bool showCoolDown = false;
	private bool isKilled = false;
	public bool IsKilled{ get { return isKilled; } set { isKilled = value; } }

	//GUI
	public Texture2D quitTextureMessage;
	public Texture2D yesTextureMessage;
	public Texture2D noTextureMessage;

	private bool isExitMenu = false;
	private float widthExitMenu = 700;
	private float heightExitMenu = 200;


	// Use this for initialization
	private void Start () {
		if(networkView.isMine) {
			HP_start = HP;
			gameCamera = GameObject.Find ("GameCamera").camera;
			gameCamera.enabled = false;
			camera.enabled = true;
		}
		else {
			camera.enabled = false;
		}
	}

	private void PlayerMove() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(0, speed.y * inputY, 0);
		Vector3 rotation = new Vector3(0, 0, rotationSpeed.x * inputX);
		
		movement *= Time.deltaTime;
		rotation *= Time.deltaTime;
		
		this.transform.Translate(movement);
		this.transform.Rotate(rotation);

	}

	// Update is called once per frame
	private void Update () {
		if(networkView.isMine) {
			//Player movements
			PlayerMove();

			//ATTACK
			if(Input.GetKey(KeyCode.P) && bulletsStorage > 0) {
				WeaponScript weapon = this.GetComponent<WeaponScript>();
				weapon.Attack();
			}

			//RESPAWN SPACESHIP
			if(isKilled) {
				isKilled = false;
				showCoolDown = true;
				camera.enabled = true;
				gameCamera.enabled = false;
				/*this.transform.position = new Vector3(-10000,-10000,0);
				float timer = coolDownTime;
				Debug.Log ("Start" + coolDownTime);

				while(timer >= 0.0f) {
					timer -= Time.deltaTime;
					Debug.Log (timer);
				}

				Debug.Log ("Finish" + timer);
				
				showCoolDown = false;*/
				HP = HP_start;
				this.transform.position = spawnPoint.transform.position;
			}

			if(Input.GetKey(KeyCode.Escape)) {
				isExitMenu = true;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collider) {
		if(networkView.isMine) {
			if(collider.gameObject.tag == "Bullet") {
				Network.Destroy(collider.gameObject);
				HP -= collider.gameObject.GetComponent<ShotScript>().damage;

				if(HP <= 0) {
					/*Network.RemoveRPCs(networkView.viewID);
					Network.Destroy(this.gameObject);*/
					gameCamera.enabled = true;
					isKilled = true;
				}
			}

			if(collider.gameObject.tag == "Armour") {
					
			}

			if(collider.gameObject.tag == "BulletsBox") {
			
			}
		}
	}
	void OnGUI() {
		if(networkView.isMine) {
			GUILayout.Space(100);
			GUILayout.Label("Remaining HP = " + HP.ToString());
			GUILayout.Space(100);
			GUILayout.Label("Remaining Bullets = " + bulletsStorage.ToString());

			if(showCoolDown) {
				GUILayout.Space(100);
				GUILayout.Label("Please wait!");
			}

			if(isExitMenu) {
				GUILayout.BeginArea(new Rect((Screen.width - widthExitMenu)/2, (Screen.height - heightExitMenu)/2, widthExitMenu, heightExitMenu)); 
				{
					GUILayout.Label(quitTextureMessage, GUIstyles.GetStyle());

					GUILayout.BeginHorizontal(); 
					{

						if(GUILayout.Button (yesTextureMessage, GUIstyles.GetStyle())) {
							Network.Destroy(this.gameObject);
							Network.Disconnect();
							network_menu_script.isChoiceDone = false;
							isExitMenu = false;
							Application.LoadLevel("menu");
						}
					
						if(GUILayout.Button (noTextureMessage, GUIstyles.GetStyle())) {
							isExitMenu = false;
						}
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndArea();
			}
		}

		if(!network_menu_script.Connected) {
			Network.Destroy(this.gameObject);
			Network.Disconnect();
			network_menu_script.isChoiceDone = false;
			isExitMenu = false;
			Application.LoadLevel("menu");
		}

	}
}

