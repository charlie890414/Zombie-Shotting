using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFunction : MonoBehaviour {

    float ZombiieSpeed = 0.03f;

    //zombie ability
    public int blood;
    public int attack;

    // Use this for initialization
    void Start () {
	}

	// Update is called once per frame
	void Update () {
		var player = GameObject.Find("Player");
		Debug.Log(player.transform.position);
		if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 6){
			if (gameObject.transform.position.y < player.transform.position.y) gameObject.transform.position += new Vector3(0, ZombiieSpeed, 0);
			else if (gameObject.transform.position.y > player.transform.position.y) gameObject.transform.position += new Vector3(0, -ZombiieSpeed, 0);
			if (gameObject.transform.position.x < player.transform.position.x) gameObject.transform.position += new Vector3(ZombiieSpeed, 0, 0);
			else if (gameObject.transform.position.x > player.transform.position.x) gameObject.transform.position += new Vector3(-ZombiieSpeed, 0, 0);
		}
		else{
			int num = Random.Range(1, 4);
			switch (num){
			case 1:
				gameObject.transform.position += new Vector3(0, ZombiieSpeed, 0);
				break;
			case 2:
				gameObject.transform.position += new Vector3(0, -ZombiieSpeed, 0);
				break;
			case 3:
				gameObject.transform.position += new Vector3(ZombiieSpeed, 0 , 0);
				break;
			case 4:
				gameObject.transform.position += new Vector3(-ZombiieSpeed, 0, 0);
				break;
			}

		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Laser")
		{
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
