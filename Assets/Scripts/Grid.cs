using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public enum ObjectType {Empty, TeamMember, ProjectOwner, ScrumMaster, Wall};

	private float tileWidth = 5.0f;
	private float tileHeight = 5.0f;

	private float gridHeight = 18.0f;
	private float gridWidth = 32.0f;

//	private ObjectType[,] ObjectMap = new ObjectType[,]{
//		{ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
//		{ObjectType.Wall,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Empty,	ObjectType.Wall},
//		{ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Wall,	ObjectType.Empty},
//
//	};

		// Use this for initialization
	void Start () {
//		TextAsset asset = Levels.TestLevel2;
//		string[,] grid = CSVReader.SplitCsvGrid(asset.text);
//		Debug.Log("size = " + (1+ grid.GetUpperBound(0)) + "," + (1 + grid.GetUpperBound(1))); 
//
//		Debug.Log (grid[1,6]);
//		CSVReader.DebugOutputGrid(grid); 
		generate ();
	}

	void generate(){
		TextAsset asset = Levels.TestLevel;
		string[,] ObjectMap = CSVReader.SplitCsvGrid(asset.text);
		Debug.Log("size = " + (1+ ObjectMap.GetUpperBound(0)) + "," + (1 + ObjectMap.GetUpperBound(1))); 
		
		Debug.Log (ObjectMap[1,6]);
		CSVReader.DebugOutputGrid(ObjectMap); 
		for(float x = -gridWidth/2; x < gridWidth/2; x++)
		{
			for(float y = -gridHeight/2; y < gridHeight/2; y++)
			{
				GameObject obj = (GameObject)Instantiate(Resources.Load ("Prefabs/" + "GridTile"));
				obj.transform.position = new Vector3(x*tileWidth, y*tileHeight, 10.0f);

				try{
					if(ObjectMap[(int)(x + gridWidth/2), (int)(y + gridHeight/2)] == "empty"){
//						print("y: " + (int)(x + gridWidth/2) + "x: " + (int)(-y - gridHeight/2));
//				
//						print("empty");
					} else {

						GameObject wall = (GameObject)Instantiate(Resources.Load ("Prefabs/" + "Wall"));
						wall.transform.position = new Vector3(x*tileWidth, -y*tileHeight - tileHeight, 1.0f);
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
