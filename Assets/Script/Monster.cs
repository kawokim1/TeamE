using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform target;
    Vector3 direction;
    public float speed = 2.0f; 
    Player player;
    float velocity;

    bool tagetOn = false;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        target = player.transform;
    }


    private void Update()
    {
        if(tagetOn)
            MoveToTarget();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tagetOn = true;
           //MoveToTarget();

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tagetOn = false;
            //MoveToTarget();

        }
    }


    public void MoveToTarget()
    {
        
        direction = (target.position - transform.position).normalized;

        velocity =  speed * Time.deltaTime;
       
        transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                               transform.position.y + (direction.y * velocity),
                                                  transform.position.z + (direction.z * velocity));
    }
}


