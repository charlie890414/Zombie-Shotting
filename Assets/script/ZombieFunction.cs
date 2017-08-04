using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFunction : MonoBehaviour {

    float ZombiieSpeed = 0.03f;

    //zombie ability
    public static int Hp;
    public static int attack;
    public Vector3 last_pos;
    public Vector3 dest = new Vector3(Random.Range(-13.9f, 13.9f), Random.Range(-10.8f, 10.8f),0);
    // Use this for initialization
    void Start () {
        Hp = (int) 50  * GamerFunction.wave * GamerFunction.wave / 2;
        attack = 2;
        last_pos = gameObject.transform.position;
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
            float x = gameObject.transform.position.x - player.transform.position.x;
            float y = gameObject.transform.position.y - player.transform.position.y;
            float tan = y / x;
            if (x > 0 && y > 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * 180 / Mathf.PI+180);
            }
            else if (x < 0 && y > 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180 - (Mathf.Atan(-tan) * 180 / Mathf.PI) + 180);
            }
            else if (x < 0 && y < 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan(tan) * 180 / Mathf.PI) + 180 + 180);
            }
            else if (x > 0 && y < 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 360 - (Mathf.Atan(-tan) * 180 / Mathf.PI) + 180);
            }
            if (gameObject.transform.position.y < player.transform.position.y) gameObject.transform.position += new Vector3(0, ZombiieSpeed, 0);
			else if (gameObject.transform.position.y > player.transform.position.y) gameObject.transform.position += new Vector3(0, -ZombiieSpeed, 0);
			if (gameObject.transform.position.x < player.transform.position.x) gameObject.transform.position += new Vector3(ZombiieSpeed, 0, 0);
			else if (gameObject.transform.position.x > player.transform.position.x) gameObject.transform.position += new Vector3(-ZombiieSpeed, 0, 0);
		}
		else{
            if (Vector3.Distance(gameObject.transform.position, dest) < 3 || Vector3.Distance(gameObject.transform.position, last_pos) < ZombiieSpeed / 2 ) {
                dest = new Vector3(Random.Range(-13.9f, 13.9f), Random.Range(-10.8f, 10.8f), 0);
            }
            last_pos = gameObject.transform.position;
            float x = gameObject.transform.position.x - dest.x;
            float y = gameObject.transform.position.y - dest.y;
            float tan = y / x;
            if (x > 0 && y > 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * 180 / Mathf.PI + 180);
            }
            else if (x < 0 && y > 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180 - (Mathf.Atan(-tan) * 180 / Mathf.PI) + 180);
            }
            else if (x < 0 && y < 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan(tan) * 180 / Mathf.PI) + 180 + 180);
            }
            else if (x > 0 && y < 0) {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 360 - (Mathf.Atan(-tan) * 180 / Mathf.PI) + 180);
            }
            if (gameObject.transform.position.y < dest.y) gameObject.transform.position += new Vector3(0, ZombiieSpeed, 0);
            else if (gameObject.transform.position.y > dest.y) gameObject.transform.position += new Vector3(0, -ZombiieSpeed, 0);
            if (gameObject.transform.position.x < dest.x) gameObject.transform.position += new Vector3(ZombiieSpeed, 0, 0);
            else if (gameObject.transform.position.x > dest.x) gameObject.transform.position += new Vector3(-ZombiieSpeed, 0, 0);
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
