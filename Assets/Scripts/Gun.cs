using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public virtual void Shoot()
    {
        //�Ѿ��� ���� 
        GameObject go = Instantiate(this.bulletPrefab);
        //��ġ ���� 
        go.transform.position = this.firePoint.position;
    }
}
