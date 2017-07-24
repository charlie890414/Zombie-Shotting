using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorl : MonoBehaviour {

    //follow player
    public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 5);
        gameObject.transform.position = vec;
    }
}
