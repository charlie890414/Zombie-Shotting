using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public GameObject Laser;

    public static int face = 0;
    public int face1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //玩家控制
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
            face = 0;
            face1 = face;
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, -0.1f, 0);
            face = 1;
            face1 = face;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            face = 2;
            face1 = face;
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
            face = 3;
            face1 = face;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Laser")
        {
            Destroy(col.gameObject);
        }
    }
}
