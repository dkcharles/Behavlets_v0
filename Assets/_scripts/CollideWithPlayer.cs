using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
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
            PointCollected();  
        }
    }

    void PointCollected()
    { 
        G_M.ballsGathered++;
        print("found " + G_M.ballsGathered + " balls");
        Destroy(gameObject);
    }
}
