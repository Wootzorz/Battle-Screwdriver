using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class generalManager : MonoBehaviour {
	public static generalManager instance;
	
	public GameObject TilePrefab;
	public GameObject UserPlayerPrefab;
	public GameObject AIPlayerPrefab;

	public int mapSize = 11;
//These are the variable definitions on the actual GameManager.
	
	List <List<Tile>> map = new List<List<Tile>>();
	List <Player> players = new List<Player>();
	int currentPlayerIndex = 0;
	
	void Awake() {
		instance = this;
// instance = this is used to mark location of a OnMouseDown
	}
	
// Use this for initialization
	void Start () {		
		generateMap();
		generatePlayers();
	}
	
	
	
//The buttons on the GUI.
	void Update () {
// Update is called once per frame	
		players[currentPlayerIndex].TurnUpdate();
	}
	
	public void nextTurn() {
		if (currentPlayerIndex + 1 < players.Count) {
			currentPlayerIndex++;
		} 
		else {
			currentPlayerIndex = 0;
// Sets new turn player # to the next player, unless we have finished all players, then starts over at 0
		}
	}
	public void moveCurrentPlayer(Tile destTile) {
		players[currentPlayerIndex].moveDestination = destTile.transform.position + 1.5f * Vector3.up;
//Moves current player to location of "this" tile	
	}
	
	void generateMap() {
		map = new List<List<Tile>>();
		for (int i = 0; i < mapSize; i++) {
			List <Tile> row = new List<Tile>();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2(i, j);
				row.Add (tile);
			}
			map.Add(row);
		}
	}
//Builds map as square of variable mapSize
	
	void generatePlayers() {
		userPlayer player;
		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize/2),1.5f, -0 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<userPlayer>();
		
		players.Add(player);
		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((mapSize-1) - Mathf.Floor(mapSize/2),1.5f, -(mapSize-1) + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<userPlayer>();
		
		players.Add(player);
				
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(4 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<userPlayer>();
		
		players.Add(player);
		
		AIPlayer aiplayer = ((GameObject)Instantiate(AIPlayerPrefab, new Vector3(6 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
		
		players.Add(aiplayer);
		//Adds players
		
	}
}
