using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_FOV_Test : MonoBehaviour
{
    RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * hit.distance, Color.red);
        }
    }

   
}
