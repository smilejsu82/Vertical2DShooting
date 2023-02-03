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

        if (Input.GetKeyDown(KeyCode.Space))    //스페이스바를 누르면 
        {
            this.Shoot();   //총알을 발사 
        }
    }

    private void Shoot()
    {
        //내가 가지고있는 Gun 이 총알을 발사 
        this.gun.Shoot();
    }
}
