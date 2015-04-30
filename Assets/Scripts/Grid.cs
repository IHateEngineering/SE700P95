using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public enum ObjectType {Empty, TeamMember, ProjectOwner, ScrumMaster, Wall};

	private float tileWidth = 5.0f;
	private float tileHeight = 5.0f;

	private float gridHeight = 18.0f;
	private float gridWidth = 32.0f;

	private ObjectType[,] ObjectMap = new ObjectType[,]{
		{ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
		{ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Empty},

	};

		// Use this for initialization
	void Start () {

		generate ();
	}

	void generate(){

		for(float x = -gridWidth/2; x < gridWidth/2; x++)
		{
			for(float y = -gridHeight/2; y < gridHeight/2; y++)
			{
				GameObject obj = (GameObject)Instantiate(Resources.Load ("Prefabs/" + "GridTile"));
				obj.transform.position = new Vector3(x*tileWidth, y*tileHeight, 10.0f);

				try{
					if(ObjectMap[(int)(y + gridHeight/2), (int)(x + gridWidth/2)] == ObjectType.Empty){
//						print("y: " + (int)(x + gridWidth/2) + "x: " + (int)(-y - gridHeight/2));
//				
//						print("empty");
					} else {
						GameObject wall = (GameObject)Instantiate(Resources.Load ("Prefabs/" + "Wall"));
						wall.transform.position = new Vector3(x*tileWidth, -y*tileHeight, 1.0f);
					}
				} catch (UnityException ex){
				}

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
