using UnityEngine;
using System.Collections;

public class network_menu_script : MonoBehaviour {
	public string connectionIP = "127.0.0.1";	
	public int portNumber = 8679;
	public Texture2D btnConnectTexture;
	public Texture2D btnHostTexture;
	public Texture2D labelIPTexture;
	public Texture2D labelPortTexture; 
	public Texture2D btnDarkSide;
	public Texture2D btnLightSide;

	private static bool connected = false;
	public static bool choiceLightDark = false;
	public static bool isChoiceDone = false; //true - light side of power, false - dark side of power
	private static string myName = "Default";
	private float tuneWindowWidth = 300;
	private float tuneWindowHeight = 300;

	public static bool Connected { get { return connected; } }
	//public static string MyName { get { return myName; } }

	private void OnConnectedToServer() {
		//Somebody joined to the server
		connected = true;
	}

	private void OnServerInitialized() {
		//Master has initialized server
		connected = true;
	}

	private void OnDisconnectedFromServer() {
		//Someone exited from the chat
		connected = false;
	}

	private void OnGUI() {
		if(!connected) {
			GUILayout.BeginArea(new Rect((Screen.width - tuneWindowWidth)/2, (Screen.height - tuneWindowHeight)/2, tuneWindowWidth, tuneWindowHeight));
			{
				GUILayout.BeginHorizontal(); 
				{	
					GUILayout.Label(labelIPTexture, GUIstyles.GetStyle());
					connectionIP = GUILayout.TextField(connectionIP);
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				GUILayout.BeginHorizontal(); 
				{
					GUILayout.Label(labelPortTexture, GUIstyles.GetStyle());
					int.TryParse(GUILayout.TextField (portNumber.ToString()), out portNumber);
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				if(GUILayout.Button(btnConnectTexture, GUIstyles.GetStyle())) {
					Network.Connect(connectionIP, portNumber);
				}

				GUILayout.Space(10);

				if(GUILayout.Button(btnHostTexture, GUIstyles.GetStyle())) {
					Network.InitializeServer(10, portNumber, true);
				}
			}
			GUILayout.EndArea();
		}
		else {
			if(!isChoiceDone) {
				if(GUI.Button(new Rect(0,0,Screen.width/2, Screen.height), "", GUIstyles.SetImageOnBG(btnLightSide))) {
					choiceLightDark = true;
					isChoiceDone = true;
				}
				if(GUI.Button(new Rect(Screen.width/2,0,Screen.width/2, Screen.height), "", GUIstyles.SetImageOnBG(btnDarkSide))) {
					choiceLightDark = false;
					isChoiceDone = true;
				}
			}

			//GUILayout.Label("Connections: " + Network.connections.Length.ToString());
		}
	}
}
