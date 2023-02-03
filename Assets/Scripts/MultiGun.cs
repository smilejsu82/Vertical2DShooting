using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    //https://docs.unity3d.com/ScriptReference/TooltipAttribute.html
    [Tooltip("right fire point")]
    public Transform firePoint2;    //right 

    public override void Shoot()
    {
        //base.Shoot();
        //ÃÑ¾ËÀ» »ý¼º 
        GameObject go1 = Instantiate(this.bulletPrefab);    //left
        GameObject go2 = Instantiate(this.bulletPrefab);    //right
        go1.transform.position = this.firePoint.position;   
        go2.transform.position = this.firePoint2.position;
    }
}
