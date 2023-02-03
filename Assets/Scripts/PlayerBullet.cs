using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        this.transform.Translate(this.transform.up * this.speed * Time.deltaTime);

        if (this.transform.position.y >= 5.73f)
        {
            //Á¦°Å 
            Destroy(this.gameObject);
        }
    }
}
