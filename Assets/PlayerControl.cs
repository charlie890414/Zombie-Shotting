using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

    public GameObject Laser;

    //剩餘子彈數
    public Text BulletNumber;

    //player ability
    public int blood;
    public int attack;


    //音效
    public AudioClip sound;
    public AudioSource source;

    public static int face = 0;
    public int face1;
    private int playerbullet;
    private float nextFire;
    //定義數值
    private const int playerbulletvalue = 25; //子彈數
    private const float cliptime=1.5f, nextFirevalue=0.0f; //子彈間隔,無須設定
    public int Bullet = playerbulletvalue;

    // Use this for initialization
    void Start () {
        playerbullet = playerbulletvalue;
        nextFire = nextFirevalue;
        BulletNumber.text = "" + playerbullet;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 player = gameObject.transform.position;
        float x = mouse.x - player.x;
        float y = mouse.y - player.y;
        float tan = y / x;
        //Debug.Log(Mathf.Atan(tan) * 180 / Mathf.PI);
        //Debug.Log(mouse);
        //Debug.Log(player);
        //Debug.Log(x);
        //Debug.Log(y);
        //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * 180 / Mathf.PI);
        if (x > 0 && y > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * 180 / Mathf.PI);
        }
        else if(x < 0 && y > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180 - (Mathf.Atan(-tan) * 180 / Mathf.PI) );
        }
        else if(x < 0 && y < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan(tan) * 180 / Mathf.PI) + 180);
        }
        else if(x > 0 && y < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 360 - (Mathf.Atan(-tan) * 180 / Mathf.PI));
        }


        //裝彈顯示
        if (!(playerbullet == playerbulletvalue && nextFire > Time.time))
        {
            BulletNumber.text = "" + playerbullet;
        }

        //玩家控制

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, -0.1f, 0);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
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
            Debug.Log(playerbullet);
            //顯示剩餘子彈數量
            //判斷是否可發射
            if (playerbullet == playerbulletvalue && nextFire > Time.time)
            {
                Debug.Log("子彈填充中");
            }
            else
            {

                //判斷方向，取得face1代碼
                


                //子彈現型，交給laser.cs設定飛行速度
                switch (face)
                {
                    case 0:
                        Vector3 pos = gameObject.transform.position + new Vector3(0, 1f, 0);
                        Instantiate(Laser, pos, Quaternion.Euler(0f, 0f, 90f));
                        break;
                    case 1:
                        Vector3 pos1 = gameObject.transform.position + new Vector3(0, -1f, 0);
                        Instantiate(Laser, pos1, Quaternion.Euler(0f, 0f, 90f));
                        break;
                    case 2:
                        Vector3 pos2 = gameObject.transform.position + new Vector3(-1f, 0, 0);
                        Instantiate(Laser, pos2, gameObject.transform.rotation);
                        break;
                    case 3:
                        Vector3 pos3 = gameObject.transform.position + new Vector3(1f, 0, 0);
                        Instantiate(Laser, pos3, gameObject.transform.rotation);
                        break;
                        
                }
                playerbullet -= 1;
                BulletNumber.text = "" + playerbullet;
                //扣一發子彈
                //若子彈歸0則換彈匣(設定下一發時間)
                if (playerbullet == 0 && nextFire < Time.time)
                {
                    nextFire = Time.time + cliptime;
                    playerbullet = playerbulletvalue;
                    
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(nextFire < Time.time)
            {
                nextFire = Time.time + cliptime;
                playerbullet = playerbulletvalue;
            }
        }
    }
}
