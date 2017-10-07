using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStartup : NetworkBehaviour
{

    public GameObject cameraPosition;

    // Use this for initialization
    void Start () {
        
        if (isLocalPlayer)
        {
            GameObject camera = GameObject.Find("MainCamera");                  //  Finds the main camera within the scene

            if (camera)
            {
                camera.gameObject.transform.parent = this.transform;                //  Sets the object as a child of this transform
                camera.transform.position = cameraPosition.transform.position;      //  Sets the relative transform to the camera position            
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
               
    }
}
