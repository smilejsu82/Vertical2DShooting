using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Gun gun;

    public float speed = 1f;

    public void Init(Gun gun)
    {
        this.gun = gun;
        this.gun.gameObject.transform.SetParent(this.transform);
        this.gun.transform.localPosition = Vector3.zero;    //new Vector3(0, 0, 0);
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        this.transform.Translate(dir.normalized * this.speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))    //�����̽��ٸ� ������ 
        {
            this.Shoot();   //�Ѿ��� �߻� 
        }
    }

    private void Shoot()
    {
        //���� �������ִ� Gun �� �Ѿ��� �߻� 
        this.gun.Shoot();
    }
}
