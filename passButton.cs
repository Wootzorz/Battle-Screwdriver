using UnityEngine;
using System.Collections;

public class passButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button(new Rect(10, 80, 100, 50), "Pass")){ 
			print ("You clicked the button.");
			generalManager.instance.nextTurn();
		}
	}
}
