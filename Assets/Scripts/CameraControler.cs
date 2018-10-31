using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public Player player;

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        transform.position = new Vector3(player.transform.position.x + 6, transform.position.y, transform.position.z);
	}



}
