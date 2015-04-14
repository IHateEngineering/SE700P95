using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (teamMemberNumber == 1) {
//			moveRight ();
//		}
	}

	public bool moveRight(){
		gameObject.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
		return true;
	}

	public void moveTo() {
	
	}

	public bool moveOtherPersonRightByTag(string tag){
		GameObject.FindGameObjectWithTag (tag).transform.Translate(Vector3.left * Time.deltaTime, Space.World);
		return true;
	}

}
