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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //T A Component of the matching type, otherwise null if no Component is found.
        //https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.LogFormat("Enemy Type: {0}", enemy.type);
            Destroy(this.gameObject);
            enemy.Explode();
        }
    }
}
