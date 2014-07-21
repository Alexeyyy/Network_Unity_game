using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Network))]
[RequireComponent(typeof(NetworkView))]

public class ServerSide : MonoBehaviour {
	private int playerCount = 0;
	public int PlayerCount { get; protected set;}

	//works when we've created server
	private void OnServerInitialized() {
		//...
	}

	//calls when a new player attends to the game
	private void OnPlayerConnected() {
		playerCount++;
	}

	//calls when one of the players is disconnected
	private void OnPlayerDisconnected(NetworkPlayer player) {
		playerCount--;
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
}
