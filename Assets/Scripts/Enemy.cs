using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public enum eType
    { 
        A, B 
    }

    public int score;
    public eType type;
    public Action<Vector3> onExplode;

    public void Explode()
    {
        this.onExplode(this.transform.position);

        Destroy(this.gameObject);
    }

}
