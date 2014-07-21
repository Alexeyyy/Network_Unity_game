using UnityEngine;
using System.Collections;

public class CreatePrefabOnServer : MonoBehaviour {

	public GameObject x_wing_fighter;
	public GameObject tie_fighter;
	public GameObject x_wing_spawnPoint;
	public GameObject tie_fighter_spawnPoint;

	private bool isCreated = false;

	private void Update()
	{
		if(network_menu_script.isChoiceDone && network_menu_script.choiceLightDark && !isCreated)
		{
			Network.Instantiate(x_wing_fighter, x_wing_spawnPoint.transform.position, Quaternion.identity,0);
			isCreated = true;
		}

		if(network_menu_script.isChoiceDone && !network_menu_script.choiceLightDark && !isCreated)
		{
			Network.Instantiate(tie_fighter, tie_fighter_spawnPoint.transform.position, Quaternion.identity, 0);
			isCreated = true;
		}
	}
}
