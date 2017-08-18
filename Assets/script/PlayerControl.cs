using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

    public GameObject Laser;
	public GameObject Gunhead;

    //剩餘子彈數
    public Text BulletNumber;

    //player ability
    public static int Hp;
    public static int attack;
    public Text HpNum;
    public static int KillNum;
    public Text killTxt;


    //音效
    public AudioClip Sound;
    public AudioClip reload;
    public float volume = 0;
    public AudioSource audio;

    public static int face = 0;
    public int face1;
    private int playerbullet;
    private float nextFire;
    //定義數值
    private const int playerbulletvalue = 30; //子彈數
    private const float cliptime=1.5f, nextFirevalue=0.0f; //子彈間隔,無須設定
    public int Bullet = playerbulletvalue;

    // Use this for initialization
    void Start () {
        playerbullet = playerbulletvalue;
        nextFire = nextFirevalue;
        BulletNumber.text = "" + playerbullet;
        audio = GetComponent<AudioSource>();
        volume = 2f;
        Hp = 100;
        attack = 50;
        HpNum.text = "HP: " + Hp;
    }
	
	// Update is called once per frame
	void Update () {

        if(GamerFunction.isPlay == true)
        {
            killTxt.text = "Kill: " + KillNum;

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
            else if (x < 0 && y > 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180 - (Mathf.Atan(-tan) * 180 / Mathf.PI));
            }
            else if (x < 0 && y < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan(tan) * 180 / Mathf.PI) + 180);
            }
            else if (x > 0 && y < 0)
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

            if (Input.GetKeyDown(KeyCode.Mouse0))
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
                    //子彈現型，交給laser.cs設定飛行速度
                    if (x > 0 && y > 0)
                    {
						Vector3 pos = Gunhead.gameObject.transform.position ;
                        Instantiate(Laser, pos, gameObject.transform.rotation);
                        audio.PlayOneShot(Sound, volume);

                    }
                    else if (x < 0 && y > 0)
                    {
                        Vector3 pos1 = Gunhead.gameObject.transform.position ;
                        Instantiate(Laser, pos1, gameObject.transform.rotation);
                        audio.PlayOneShot(Sound, volume);
                    }
                    else if (x < 0 && y < 0)
                    {
						Vector3 pos2 = Gunhead.gameObject.transform.position ;
                        Instantiate(Laser, pos2, gameObject.transform.rotation);
                        audio.PlayOneShot(Sound, volume);
                    }
                    else if (x > 0 && y < 0)
                    {
						Vector3 pos3 = Gunhead.gameObject.transform.position ;
                        Instantiate(Laser, pos3, gameObject.transform.rotation);
                        audio.PlayOneShot(Sound, volume);
                    }
                    playerbullet -= 1;
                    BulletNumber.text = "" + playerbullet;
                    //扣一發子彈
                    //若子彈歸0則換彈匣(設定下一發時間)
                    if (playerbullet == 0 && nextFire < Time.time)
                    {
                        nextFire = Time.time + cliptime;
                        playerbullet = playerbulletvalue;
                        audio.PlayOneShot(reload, volume);
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                audio.PlayOneShot(reload, volume);
                if (nextFire < Time.time)
                {
                    nextFire = Time.time + cliptime;
                    playerbullet = playerbulletvalue;

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "zombie")
        {
            if (Hp <= 0)
            {
                Destroy(gameObject);
                HpNum.text = "" + 0;
                KillNum = 0;
                GamerFunction.isPlay = false;
                GamerFunction.PlayerDead();
            }
            else
            {
                Hp -= ZombieFunction.attack;
                HpNum.text = "HP: " + Hp;
            }
        }
        
    }
}
