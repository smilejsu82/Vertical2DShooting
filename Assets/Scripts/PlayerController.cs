using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public GameObject boomPrefab;
    public Gun gun;

    public float speed = 1f;
    public System.Action<Power> onGetPower;

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

        if (Input.GetKeyDown(KeyCode.B))
        {
            this.Boom();
        }
    }

    private void Boom()
    {
        GameObject go = Instantiate(this.boomPrefab);
        go.GetComponent<Boom>().Init();
        go.transform.position = Vector3.zero;
    }

    private void Shoot()
    {
        //���� �������ִ� Gun �� �Ѿ��� �߻� 
        this.gun.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Power") {
            Debug.Log("������ ȹ��");

            Power power = collision.gameObject.GetComponent<Power>();

            //��Ƽ������ ���� 
            this.onGetPower(power);

            Destroy(collision.gameObject);  //������ ���� 

        }
    }

    public void AttachGun(Gun gun)
    {
        this.gun = gun;
        this.gun.transform.SetParent(this.transform);
    }

    public void DettachGun()
    {
        //�ڽ����� ���� Gun���� ������Ʈ�� ���� 
        Destroy(this.gun.gameObject);
        Debug.LogFormat("gun: {0}", this.gun);
        this.gun = null;
    }
}
