using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerFunction : MonoBehaviour
{

    public static GamerFunction Instance;

    //ui
    public GameObject PlayButton;
    public GameObject RestartButton;
    public GameObject QuitButton;
    public static GameObject re;
    public static GameObject qu;
    public Text wavetxt;

    //zombie
    public GameObject Zombie;
    public static int wave = 1;
    public int zomnum = 10;

    //zombie spawn speed
    public static int zomps = 0;

    public static bool isPlay = false;

    // Use this for initialization
    void Start()
    {
        Instance = this; 
        RestartButton.SetActive(false);
        re = RestartButton;
        qu = QuitButton;
    }

    // Update is called once per frame
    void Update()
    {

        zomps++;
        if (zomps >= 100)
        {
            SpawnZombie(4);
            zomps = 0;
            zomnum -= 4;
            if(zomnum == 0)
            {

                wave++;
                zomnum = 10 * wave * 3 / 2;
                float time = Time.time;
                for(int i = 0; i > 0; i++)
                {
                    if(true)
                    {
                        wavetxt.text = "WAVE: " + wave;
                        break;
                    }
                }

            }
        }

    }

    void SpawnZombie(int num)
    {
        if(isPlay == true)
        {
            for(int i = num; i > 0; i--)
            {
                int side = Random.Range(0, 4);
                switch (side)
                {
                    case 0:
                        Vector3 pos1 = new Vector3(Random.Range(1f, 10.5f), 10.8f, 0);
                        Instantiate(Zombie, pos1, Quaternion.Euler(0f, 0f, -90f));
                        break;

                    case 1:
                        Vector3 pos2 = new Vector3(13.9f, Random.Range(-9f, 0.5f), 0);
                        Instantiate(Zombie, pos2, Quaternion.Euler(0f, 0f, 180f));
                        break;

                    case 2:
                        Vector3 pos3 = new Vector3(-13.9f, Random.Range(-9f, 0.5f), 0);
                        Instantiate(Zombie, pos3, Quaternion.Euler(0f, 0f, 0f));
                        break;

                    case 3:
                        Vector3 pos4 = new Vector3(Random.Range(1f, 10.5f), -10.8f, 0);
                        Instantiate(Zombie, pos4, Quaternion.Euler(0f, 0f, 90f));
                        break;
                }
            }
        }

    }


    public void PlayGame()
    {
        
        QuitButton.SetActive(false);
        PlayButton.SetActive(false);
        isPlay = true;
    }

    public void ResetGame() //RestartButton的功能

    {

        Application.LoadLevel(Application.loadedLevel); //讀取關卡(已讀取的關卡)
        PlayButton.SetActive(false);
        QuitButton.SetActive(false);

    }

    public void QuitGame() //QuitButton的功能

    {

        Application.Quit(); //離開應用程式

    }

    public static void PlayerDead()
    {
        re.SetActive(true);
        qu.SetActive(true);
    }
}
