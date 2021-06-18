using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour : MonoBehaviour
{
    public Transform target;
    NavMeshAgent _AI;
    // Start is called before the first frame update
    void Start()
    {
        _AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _destination = target.position;
        _AI.destination = _destination;
    }
}
