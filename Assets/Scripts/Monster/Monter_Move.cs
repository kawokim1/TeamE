using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monter_Move : MonoBehaviour
{
    float wait= Random.Range(1,3.5f);
    float minX, minZ, maxX, maxZ;
    Vector3 dir;

   
    public IEnumerator Move()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(wait);
            
        }
    }
}
