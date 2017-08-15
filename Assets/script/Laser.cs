using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float speed=15;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    int face = PlayerControl.face;
    void Update () {
        switch (face)
        {
            case 0:
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                break;
            case 1:
                transform.Translate(Vector2.left * Time.deltaTime * speed);
                break;
            case 2:
                transform.Translate(Vector2.left * Time.deltaTime * speed);
                break;
            case 3:
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("擊中");
        Destroy(this.gameObject);

    }
}
