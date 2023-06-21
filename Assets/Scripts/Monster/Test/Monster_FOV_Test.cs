using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_FOV_Test : MonoBehaviour
{
    Vector3 dir = new Vector3(3,3,3);
    RaycastHit hit;
    Collider m_collider;
    private void Awake()
    {
        m_collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if (Physics.BoxCast(m_collider.bounds.center, transform.localScale, transform.forward,out hit,transform.rotation, 5))
        {
            Debug.DrawRay(m_collider.bounds.center, hit.point, Color.red);
        }
    }

   
}
