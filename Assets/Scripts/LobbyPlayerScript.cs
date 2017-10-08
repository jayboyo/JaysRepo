using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject[] playerSpawns = GameObject.FindGameObjectsWithTag("lobbySpawn");

        foreach (GameObject x in playerSpawns)
        {
            if (!x.GetComponent<LobbySpawnPoint>().inUse)
            {
                transform.position = x.transform.position;
                x.GetComponent<LobbySpawnPoint>().inUse = true;
                break;
            }

        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
