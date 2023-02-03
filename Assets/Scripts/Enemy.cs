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

    public float speed = 2f;
    public int score;
    public eType type;
    public Action<Vector3> onExplode;

    public void Explode()
    {
        if(this.onExplode!= null)
            this.onExplode(this.transform.position);

        Destroy(this.gameObject);
    }

    private void Update()
    {
        this.transform.position += this.speed * Time.deltaTime * Vector3.down;
    }

}
