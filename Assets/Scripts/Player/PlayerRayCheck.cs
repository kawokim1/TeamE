using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCheck : MonoBehaviour
{
    //public CapsuleCollider collider;
    public Vector3 colliderCenterInLocalSpace;

    [field: SerializeField] public float Height { get; private set; } = 1.44f;
    [field: SerializeField] public float CenterY { get; private set; } = 0.72f;
    [field: SerializeField] public float Readius { get; private set; } = 0.2f;

    private void Awake()
    {
        //collider = GetComponent<CapsuleCollider>();
    }

    public void UpdateCollider()
    {
        //colliderCenterInLocalSpace = collider.center;
    }
}
