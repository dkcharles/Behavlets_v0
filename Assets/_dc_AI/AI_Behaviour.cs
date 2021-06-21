using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState {patrol, chase, attack}
public class AI_Behaviour : MonoBehaviour
{
    public Transform target;
    public PlayerState playerState;
    private Animator _animator;
    NavMeshAgent _AI;
    // Start is called before the first frame update
    void Start()
    {
        _AI = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        playerState = PlayerState.patrol;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerPosition = target.position;     // Check Player Distance
        float playerDistance = (_playerPosition - this.transform.position).magnitude;
        _animator.SetFloat("PlayerDistance", playerDistance);   // player distance changes AI state
        // print("Player Distance is " + playerDistance);
    }
}
