using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string IP = "127.0.0.1";
	public int Port = 25001;
	public GameObject target;
	public string username ="";
	bool RegisterUI = false;
	bool LoginUI = false;
	void OnGUI()
	{
		if(Network.peerType == NetworkPeerType.Disconnected)
		{
			if(GUI.Button(new Rect(100,100,100,25),"Start Client"))
			{
				Network.Connect(IP,Port);
			}
			if(GUI.Button(new Rect(100,125,100,25),"Start Server"))
			{
				Network.InitializeServer(10,Port);
			}
		}
		else{
			if(Network.peerType == NetworkPeerType.Client)
			{
				if(RegisterUI == true && LoginUI == false)
				{
					username = GUI.TextArea(new Rect(100,125,110,25),username);
					if(GUI.Button(new Rect(100,150,110,25),"Register"))
					{
						networkView.RPC("Register",RPCMode.Server,username);
						RegisterUI = false;
					}
				}
				else if(LoginUI == true && RegisterUI == false)
				{
					username = GUI.TextArea(new Rect(100,125,110,25),username);
					if(GUI.Button(new Rect(100,150,110,25),"Login"))
					{
						networkView.RPC("Login",RPCMode.Server,username);
					}
				}
				else
				{
					GUI.Label(new Rect(100,100,100,25),"Client");
					if(GUI.Button(new Rect(100,125,110,25),"Login"))
					{
						LoginUI = true;
					}
					if(GUI.Button(new Rect(100,150,110,25),"Register"))
					{
						RegisterUI = true;
						
					}
					if(GUI.Button(new Rect(100,175,110,25),"Logout"))
					{
						Network.Disconnect(250);
					}
				}

			}
			if(Network.peerType == NetworkPeerType.Server)
			{
				GUI.Label(new Rect(100,100,100,25),"Server");
				GUI.Label(new Rect(100,125,100,25),"Conections" + Network.connections.Length);
				if(GUI.Button(new Rect(100,150,100,25),"Logout"))
				{
					Network.Disconnect(250);
					
				}
			}
		}
	}
	[RPC]
	void Login(string Username)
	{
		if(Network.isServer)
		{
			bool checkUserName = PlayerPrefs.HasKey(Username);
			if(checkUserName == true)
			{
				networkView.RPC("LoadLevel",RPCMode.Others);
			}
		}
		Debug.Log("Login");
	}
	[RPC]
	void LoadLevel()
	{
		if(Network.isClient)
		{
			if(Application.loadedLevel == 0)
			{
				Application.LoadLevel(1);
			}
		}
	}
	[RPC]
	void Register(string Username)
	{
		if(Network.isServer)
		{
			PlayerPrefs.SetString(Username,Username);
		}
		Debug.Log("Register");
	}
	/*
	[RPC]
	void AskForColor()
	{
		if(Network.isServer)
		{
			networkView.RPC("ChangeColor",RPCMode.All);
			Debug.Log("Server has changed all colors!");
		}
		else{

		}
	}
	[RPC]
	void ChangeColor()
	{
		target.renderer.material.color = Color.green;
	}*/
}
