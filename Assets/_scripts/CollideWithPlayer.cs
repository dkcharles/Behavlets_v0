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
        G_M.ballsGathered++;
        inventory.ballsCollected += 1;
        print("found " + G_M.ballsGathered + " balls");
        Destroy(gameObject);
    }
}
