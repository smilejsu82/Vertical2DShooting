using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float duration = 2f;

    public void Init()
    {
        StartCoroutine(this.WaitForBoom());
    }

    private IEnumerator WaitForBoom()
    {
        yield return new WaitForSeconds(this.duration);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Explode();
        }
    }
}
