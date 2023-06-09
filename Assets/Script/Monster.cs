using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform target;
    Vector3 direction;
    public float speed = 2.0f; 
    Player player;
    float velocity;
    private Quaternion targetRotation;
    public float rotationSpeed = 5.0f;


    bool tagetOn = false;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        target = player.transform;
        
    }


    private void Update()
    {
        if (tagetOn)
        {

            
            MoveToTarget();
        }
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
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        direction = (target.position - transform.position).normalized;
       

        velocity =  speed * Time.deltaTime;
       
        transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                               transform.position.y + (direction.y * velocity),
                                                  transform.position.z + (direction.z * velocity));
        
    }
    //public void LookAtTarget()
    //{
    //    Vector3 direction = target.position - transform.position;
    //    direction.y = 0; 
    //    targetRotation = Quaternion.LookRotation(direction);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 
    //}

}


