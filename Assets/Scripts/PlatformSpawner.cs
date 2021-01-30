using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject Platform;
    public GameObject diamonds;
    Vector3 lastPos;
    float size;
    public bool gameover;
	// Use this for initialization
	void Start ()
    {
        gameover = false;
        lastPos = Platform.transform.position;
        size = Platform.transform.localScale.x;

        for (int i=0;i<20;i++)
        {
            SpawnPlatforms();
        }  
	}
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }
	// Update is called once per frame
	void Update () {
	    if(GameManager.instance.gameOver==true)
        {
            CancelInvoke("SpawnPlatforms");
        }       
	}

    private void SpawnPlatforms()
    {
       int Rand = Random.Range(0, 6);
        if (Rand < 3)
        {
            SpawnX();
        }
        else if(Rand>=3)
        {
            SpawnZ();
        }
    }
    private void SpawnX()
    {
        Vector3 Pos = lastPos;
        Pos.x += size;
        lastPos = Pos;
        Instantiate(Platform, Pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds,new Vector3(Pos.x,Pos.y+1,Pos.z),diamonds.transform.rotation);
        }
    }

    private void SpawnZ()
    {
        Vector3 Pos = lastPos;
        Pos.z += size;
        lastPos = Pos;
        Instantiate(Platform, Pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(Pos.x, Pos.y + 1, Pos.z), diamonds.transform.rotation);
        }

    }
}
