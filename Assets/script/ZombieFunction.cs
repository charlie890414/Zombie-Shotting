using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFunction : MonoBehaviour {

    float ZombiieSpeed = 0.03f;

    //zombie ability
    public static int Hp;
    public static int attack;

    // Use this for initialization
    void Start () {
        Hp = (int) 50  * GamerFunction.wave * GamerFunction.wave / 2;
        attack = 2;
	}

	// Update is called once per frame
	void Update () {
        
        if(GamerFunction.isPlay == false)
        {
            Destroy(gameObject);
        }

		var player = GameObject.Find("Player");
		//Debug.Log(player.transform.position);
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
            Hp -= PlayerControl.attack;
		}

        //若將失血量為0則destory
        if (Hp <= 0)
        {
            Destroy(gameObject);
            PlayerControl.KillNum += 1;
            ZombieFunction.Hp = 1;

        }
    }

    private void OnDestroy()
    {
        
    }
}
