using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public virtual void Shoot()
    {
        //총알을 생성 
        GameObject go = Instantiate(this.bulletPrefab);
        //위치 설정 
        go.transform.position = this.firePoint.position;
    }
}
