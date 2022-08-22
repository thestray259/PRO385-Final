using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Companion : Agent
{
    [SerializeField] GameObject player;
    //[SerializeField] CharacterController companionController; 

    public FloatRef playerDistance;
    public Vector3 destination; 

    void Start()
    {
        
    }

    void Update()
    {
        // it's spinning on the y a bunch???

        //playerDistance.value = (player != null) ? (Vector3.Distance(transform.position, player.transform.position)) : float.MaxValue; // I think the problem is here
        playerDistance.value = Vector3.Distance(this.transform.position, player.transform.position); 

        if (playerDistance.value >= 1.0f) // if player is more than 1.5f away from companion
        {
            // move towards player
            destination = player.transform.position;
            movement.MoveTowards(destination);
        }
        else movement.Stop(); 
    }
}
