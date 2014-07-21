using UnityEngine;
using System.Collections;

public class MenuServer : MonoBehaviour {
	const int NETWORK_PORT = 4585; //сетевой порт
	const int MAX_CONNECTIONS = 20; //макс. число входяших подключений
	const bool USE_NAT = false; //использовать NAT
	
	private string remoteServer = "127.0.0.1"; //адрес сервера (localhost)
	
	private void OnGUI() {
		//если не подключен
		if(Network.peerType == NetworkPeerType.Disconnected) {
			//Запустить сервер
			if(GUILayout.Button("Start server")) {
				Network.InitializeSecurity(); //защита
				Network.InitializeServer(MAX_CONNECTIONS, NETWORK_PORT, USE_NAT);
			}
			//отступ
			GUILayout.Space(30f);
			
			remoteServer = GUILayout.TextField(remoteServer); //поле адреса сервера
			
			if(GUILayout.Button("Connect to server")) {
				Network.Connect(remoteServer, NETWORK_PORT); //подключаемся к серверу
			}
		}
		//во время подкл
		else if(Network.peerType == NetworkPeerType.Connecting) { 
			GUILayout.Label("Trying to connect to server...");
		}
		//во всех остальных случаях
		else {
			if(GUILayout.Button("Disconnect")) {
				Network.Disconnect(); //отключаем всех клиентов, либо отключаемся от сервера
			}
		}
	}
	
	private void OnFailedToConnect(NetworkConnectionError error) {
		Debug.Log("Failed to connect: " + error.ToString()); //выводим ошибку подключения
	}
	
	private void OnDisconnectedFromServer(NetworkDisconnection info) {
		if(Network.isClient) {
			Debug.Log("Disconnected from server " + info.ToString());
		}
		else {
			Debug.Log("Connection is closed"); //сообщение выводится при выключении сервера
		}
	}
	
	private void OnConnectedToServer() {
		Debug.Log("Connected to Server"); //сообщение выводится при успешном подключении к  серверу
	}
}