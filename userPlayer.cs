using UnityEngine;
using System.Collections;
using UnityEditor;

public class userPlayer : Player {
	public static userPlayer instance;

	public Material origional;
	public Material chosen;
	public void resetMaterial() {
		renderer.material = origional;
	}
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public override void TurnUpdate ()
	{
		renderer.material = chosen;
		if (Vector3.Distance(moveDestination, transform.position) <= moveDistance) 
		{
			if (Vector3.Distance(moveDestination, transform.position) > 0.1f)
			{
				transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;
			
				if (Vector3.Distance(moveDestination, transform.position) <= 0.1f) 
				{
					transform.position = moveDestination;
					resetMaterial();
					generalManager.instance.nextTurn();
				}
			}
		}
		else
		{
			Debug.Log("too far");
			return;
		}
		
		base.TurnUpdate ();
	}
}
