/*using UnityEngine;
using System.Collections;

public class CreateField : MonoBehaviour {
	public Vector2 startPoint;
	public GameObject[] field;
	public int x_quantity;
	public int y_quantity;


	private void DrawField(Vector2 startPosition, int x_count_cells, int y_count_cells, Texture2D cell_sprite) {
		for(int i = 0; i < x_count_cells; i++) {
			for(int j = 0; j < y_count_cells; j++) {
				Instantiate(cell_sprite, new Vector2(startPosition.x * i, startPosition.y * j), Quaternion.identity);

				Debug.Log("Created!");
			}
		}
	}

	// Use this for initialization
	void Start () {
		DrawField(startPoint, x_quantity, y_quantity, cell_sprite);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}*/
