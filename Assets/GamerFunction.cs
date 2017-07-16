using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerFunction : MonoBehaviour
{

    //zombie
    public GameObject Zombie;


    //zombie spawn speed
    public int zomps = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        zomps++;
        if (zomps == 10)
        {
            SpawnZombie();
            zomps = 0;
        }

    }

    void SpawnZombie()
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
                Instantiate(Zombie, pos3, Quaternion.Euler(0f, 0f, 0));
                break;

            case 3:
                Vector3 pos4 = new Vector3(Random.Range(1f, 10.5f), -10.8f, 0);
                Instantiate(Zombie, pos4, Quaternion.Euler(0f, 0f, 90f));
                break;
        }

    }
}
