using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class Companion : Agent
{
    [SerializeField] GameObject player;
    [SerializeField] NavMeshMovement navMeshMovement; 
    //[SerializeField] CharacterController companionController; 

    public float speed = 5; 
    public FloatRef playerDistance;
    public Vector3 destination;
    public Quaternion rotation;
    public Vector3 forward; 

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
        
        //Vector3 destination = transform.position + forward * Random.Range(10f, 15f);

        playerDistance.value = Vector3.Distance(this.transform.position, player.transform.position);

        if (playerDistance.value >= 2.5f) // if player is too far away from companion 
        {
            // move towards player
            rotation = Quaternion.AngleAxis(Random.Range(-90, 90), Vector3.up);
            forward = rotation * Vector3.forward;

            destination = player.transform.position + forward;// * Random.Range(1f, 3f);// + new Vector3(1, 0, 1);
            if (navMeshMovement.navMeshAgent.isStopped == true)
            {
                movement.Resume();
                //movement.MoveTowards(destination);
            }
            else movement.MoveTowards(destination); 
            
            if (playerDistance.value <= 2.4f)
            {
                movement.Stop(); 
            }

        }
        //else movement.Stop();
    }
}
