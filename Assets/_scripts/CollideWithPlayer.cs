using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    public Inventory inventory;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {   
        print("pop!");
        if (other.gameObject.tag == "Player")
        {           
            PointCollected(other.gameObject);  
        }
    }

    void PointCollected(GameObject go)
    { 
        G_M.ballsGathered++;            // balls collected stored in game manager singleton - persistent between scenes 
        inventory.ballsCollected += 1;  // balls collected stored in Scriptable object (Inventory) - persistent between plays
        print("found " + G_M.ballsGathered + " balls");
        Destroy(gameObject);            // delete ball after collected. Though often better to return to a ball collection for recyling
    }
}
