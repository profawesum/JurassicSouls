using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//used to detect audio and visual sources
public class Detect : MonoBehaviour
{

    //used to hold the player
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {

        //TODO::Find the player
        //TODO:: Find the listeners
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit)) {
            print(hit.distance);
        }

        //draws a line from the front of the enemy
        Vector3 forward = transform.TransformDirection(Vector3.forward) * hit.distance;
        Debug.DrawRay(transform.position, forward, Color.green);

        Vector3 targetDir = player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 60.0f && hit.distance < 10.0f)
        {
            SeenPlayer();
        }
        else {
            float step = 1 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
        }
    }


    //what to do when the ai has seen the player
    void SeenPlayer() {
      
        float step = 1 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

    }

    //what to do when the ai has heard the player
    void HeardPlayer() { 
    
    
    }


}
