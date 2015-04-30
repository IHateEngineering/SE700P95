using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// determine the game window's current aspect ratio
		Screen.orientation = ScreenOrientation.Landscape;
		Camera.main.orthographicSize = 50.0f;
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
