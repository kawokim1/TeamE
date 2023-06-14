using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Monter_Move : Monster
{
    //float wait= Random.Range(1,3.5f);
    //Vector3 dir = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
    //Vector3 moveDirection;
    //Spawner spawner;
    //float Radius;

    //private void Awake()
    //{
    //    spawner= FindObjectOfType<Spawner>();
    //    spawnPosition = transform.position;


    //}

    //public IEnumerator Move()
    //{
    //    Collider collider = spawner.GetComponent<Collider>();
    //    Radius = collider.bounds.extents.magnitude;
    //   float distance = (transform.position - collider.bounds.center).magnitude;
    //    while (true)
    //    {
    //        moveDirection = dir - transform.position;
    //        moveDirection.Normalize();

    //        if (distance < Radius)
    //        {
    //            transform.Translate(moveDirection * Time.fixedDeltaTime * speed);
    //        }
    //        if(distance >= Radius)
    //        {
    //            yield return new WaitForSeconds(wait);
    //            dir = spawnPosition;
    //            transform.Translate(moveDirection * Time.fixedDeltaTime * speed);
    //        }
    //    }
    //}
}
