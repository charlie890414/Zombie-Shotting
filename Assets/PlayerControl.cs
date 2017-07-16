using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {

    public GameObject Laser;

    public static int face = 0;
    public int face1;
    private int playerbullet;
    private float nextFire;
    //定義數值
    private const int playerbulletvalue = 1; //子彈數
    private const float cliptime=0.3f, nextFirevalue=0.0f; //子彈間隔

    // Use this for initialization
    void Start () {
        playerbullet = playerbulletvalue;
        nextFire = nextFirevalue;
    }
	
	// Update is called once per frame
	void Update () {
        //玩家控制

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, -0.1f, 0);
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
            
        }
        if (Input.GetKeyDown(KeyCode.R) && nextFire < Time.time)
        {
            nextFire = Time.time + cliptime;
            playerbullet = playerbulletvalue;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log(playerbullet);
            //顯示剩餘子彈數量
            if (playerbullet == 0 && nextFire < Time.time)
            {
                nextFire = Time.time + cliptime;
                playerbullet = playerbulletvalue;
            }
            else if (playerbullet == playerbulletvalue && nextFire > Time.time)
            {
                Debug.Log("子彈填充中");
            }
            else
            {
                playerbullet -= 1;
                switch (face)
                {
                    case 0:
                        Vector3 pos = gameObject.transform.position + new Vector3(0, 2f, 0);
                        Instantiate(Laser, pos, Quaternion.Euler(0f, 0f, 90f));
                        break;
                    case 1:
                        Vector3 pos1 = gameObject.transform.position + new Vector3(0, -2f, 0);
                        Instantiate(Laser, pos1, Quaternion.Euler(0f, 0f, 90f));
                        break;
                    case 2:
                        Vector3 pos2 = gameObject.transform.position + new Vector3(-2f, 0, 0);
                        Instantiate(Laser, pos2, gameObject.transform.rotation);
                        break;
                    case 3:
                        Vector3 pos3 = gameObject.transform.position + new Vector3(2f, 0, 0);
                        Instantiate(Laser, pos3, gameObject.transform.rotation);
                        break;
                }
            }
        }


        if (Input.GetKey(KeyCode.W))
        {
            face = 0;
            face1 = face;
        }
        if (Input.GetKey(KeyCode.S))
        {
            face = 1;
            face1 = face;
        }
        if (Input.GetKey(KeyCode.A))
        {
            face = 2;
            face1 = face;
        }
        if (Input.GetKey(KeyCode.D))
        {
            face = 3;
            face1 = face;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Laser")
        {
            Destroy(col.gameObject);
        }
    }
}
