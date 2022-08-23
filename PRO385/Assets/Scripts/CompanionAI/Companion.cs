using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class Companion : Agent
{
    [SerializeField] GameObject player;
    //[SerializeField] CharacterController companionController; 

    public float speed = 5; 
    public FloatRef playerDistance;
    public Vector3 destination; 

    void Start()
    {
        
    }

    void Update()
    {
        Move(); 
    }

    void Move()
    {
        // it's spinning on the y a bunch???

        playerDistance.value = Vector3.Distance(this.transform.position, player.transform.position);

        if (playerDistance.value >= 2.5f) // if player is too far away from companion 
        {
            // move towards player
            destination = player.transform.position;// + new Vector3(1, 0, 1);
            movement.MoveTowards(destination);
            //if (playerDistance.value! >= 2.5f) movement.Stop(); 
        }
        //else movement.Stop();
    }
}
