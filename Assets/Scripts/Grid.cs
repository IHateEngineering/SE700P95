using UnityEngine;
using System.Collections;
using System;

public class Grid : MonoBehaviour {

	public enum ObjectType {Empty, TeamMember, ProjectOwner, ScrumMaster, Wall};

	private float tileWidth = 5.0f;
	private float tileHeight = 5.0f;

	private float gridHeight = 18.0f;
	private float gridWidth = 32.0f;


		// Use this for initialization
	void Start () {
		generate ();
	}

	void generate(){
		string[,] ObjectMap = LevelManager.Instance.MakeCurrentTestLevelArray();
		for(float x = -gridWidth/2; x < gridWidth/2; x++)
		{
			for(float y = -gridHeight/2; y < gridHeight/2; y++)
			{
				GameObject gridTile = (GameObject)Instantiate(Resources.Load (PrefabStrings.GridTile));
				gridTile.transform.position = new Vector3(x*tileWidth, y*tileHeight, 10.0f);

				GameObject obj = null;
				try{
					string currentCSVString = ObjectMap[(int)(x + gridWidth/2), (int)(y + gridHeight/2)];
					if(currentCSVString == CSVStrings.Empty){
						//do nothing
					} else if(currentCSVString == CSVStrings.Wall){
						obj = (GameObject)Instantiate(Resources.Load (PrefabStrings.Wall));
					}else if(currentCSVString == CSVStrings.ProjectOwner){
						obj = (GameObject)Instantiate(Resources.Load (PrefabStrings.ProjectOwner));
					}else if(currentCSVString == CSVStrings.ScrumMaster){
						obj = (GameObject)Instantiate(Resources.Load (PrefabStrings.ScrumMaster));
					}else if(currentCSVString == CSVStrings.TeamMember){
						obj = (GameObject)Instantiate(Resources.Load (PrefabStrings.TeamMember));
					}
					obj.transform.position = new Vector3(x*tileWidth, -y*tileHeight - tileHeight, 1.0f);
				} catch (Exception ex){
				}

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
