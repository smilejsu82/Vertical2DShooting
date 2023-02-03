using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
        AnimatorClipInfo[] arr =  this.anim.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(arr.Length);
        //Debug.Log(arr[0].clip);
        //Debug.Log(arr[0].clip.name);
        //Debug.Log(arr[0].clip.length);

        StartCoroutine(this.WaitForAnimation(arr[0].clip.length));
    }

    private IEnumerator WaitForAnimation(float length)
    {
        yield return new WaitForSeconds(length);

        Destroy(this.gameObject);
    }

}
