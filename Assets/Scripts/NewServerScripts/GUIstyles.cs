using UnityEngine;
using System.Collections;

public static class GUIstyles {
	public static  GUIStyle GetStyle() {
		GUIStyle style = new GUIStyle();
		style.normal.background = null;
		return style;
	}

	public static GUIStyle SetImageOnBG(Texture2D texture) {
		GUIStyle style = new GUIStyle();
		style.normal.background = texture;
		return style;
	}
}
