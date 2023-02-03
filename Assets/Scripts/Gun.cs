using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum eType
    { 
        Single, Multiple 
    }

    public eType type;
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
