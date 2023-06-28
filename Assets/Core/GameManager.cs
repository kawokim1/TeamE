using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    public float HP = 100.0f;
    public float attack = 10.0f;
}
