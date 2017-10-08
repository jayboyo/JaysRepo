using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent nav;
    Vector3 moveLocation;

    private void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        moveLocation = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));    // Sets random move location
        nav.SetDestination(moveLocation);
    }
    	
	void Update () {

        if (nav.remainingDistance < 10.0f) {    //  Target is close enough to move marker so set new one

            moveLocation = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));
            nav.SetDestination(moveLocation);
        }
        

    }
}
