using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int x = 0; x < 5; x++)
		{
			for(int y = 0; y < 5; y++)
			{
				GameObject obj = (GameObject)Instantiate(Resources.Load ("Prefabs/" + "GridTile"));
				obj.transform.position = new Vector3(x, 0, y);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
