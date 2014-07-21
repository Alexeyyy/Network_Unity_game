using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Network))]
[RequireComponent(typeof(NetworkView))]

public class ClientSide : MonoBehaviour {

	private void OnDisconnectedFromServer(NetworkDisconnection info) {
		Network.DestroyPlayerObjects(Network.player); //delete my player from game
	}


}
