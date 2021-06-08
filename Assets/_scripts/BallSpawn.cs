using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public int spawnTime = 15;
    public int numberSpawns = 5;
    public GameObject ballPrefab;
    private IEnumerator coroutine;
    void Start()
    {    
            coroutine = SpawnObject();
            StartCoroutine(coroutine);
    }

    void Update()
    {   

    }

    IEnumerator SpawnObject()
    {

            print("Start Spawning");
            for (int i=0;i<numberSpawns; ++i)
            {
                yield return StartCoroutine("Wait");
                GameObject ballInstance = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
                print("Spawning " + i);
            }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
    }

}
