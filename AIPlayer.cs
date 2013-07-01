using UnityEngine;
using System.Collections;

public class AIPlayer : Player {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//hey todd did this work with git?
	public override void TurnUpdate ()
	{
		transform.renderer.material.color = Color.red;
		if (Vector3.Distance(moveDestination, transform.position) <= moveDistance) 
			{
			if (Vector3.Distance(moveDestination, transform.position) > 0.1f)
				{
				transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;
			
				if (Vector3.Distance(moveDestination, transform.position) <= 0.1f) 
					{
					transform.position = moveDestination;
					transform.renderer.material.color = Color.white;
					generalManager.instance.nextTurn();
					}
				}
			}
			
		base.TurnUpdate ();
	}
}
