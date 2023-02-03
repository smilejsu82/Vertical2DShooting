using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public GameObject explosionPrefab;
    public GameObject powerPrefab;

    public PlayerController player;
    public Enemy[] enemyPrefabs;
    public Text txtScore;

    private int score;  //total

    //Awake - Init - Start - Update 
    public void Init(GameEnums.eGunType selectedGunType)
    {
        
        this.StartCoroutine(this.GenerateEnemy());

        this.player.onExplode = () =>
        {
            GameObject go = Instantiate(this.explosionPrefab);
            go.transform.position = this.player.transform.position;

            Destroy(this.player.gameObject);
        };

        this.player.onGetPower = (power) => {

            if (this.player.gun.type == Gun.eType.Single)
            {
                this.player.DettachGun();
                //��Ƽ�� ���� -> AttachGun
                Gun gun = this.CreateGun(GameEnums.eGunType.Multiple);
                this.player.AttachGun(gun);
            }
            else
            {
                score += 200;   //���ھ� ���� 
                this.txtScore.text = score.ToString();  //UI ���� 
            }

        };


        //���� ����� 
        Gun gun = this.CreateGun(selectedGunType);

        //�÷��̾�� ���� ���� �Ѵ� 
        this.player.Init(gun);
    }

    private IEnumerator GenerateEnemy()
    {
        while (true) {
            this.CreateEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    private void CreateEnemy()
    {
        var go = Instantiate(this.enemyPrefabs[Random.Range(0, 2)]);
        go.transform.position = new Vector3(Random.Range(-2.78f, 2.78f), 6, 0);

        var enemy = go.GetComponent<Enemy>();
        enemy.onExplode = (fxPos) => {
            score += enemy.score;
            this.txtScore.text = score.ToString();

            //����Ʈ ���� 
            GameObject go = Instantiate(this.explosionPrefab);
            go.transform.position = fxPos;

            //������ ���� 
            GameObject powerGo = Instantiate(this.powerPrefab);
            powerGo.transform.position = fxPos;
            
        };
        
    }


    private Gun CreateGun(GameEnums.eGunType gunType)
    {
        int index = (int)gunType;
        GameObject prefab = this.gunPrefabs[index];
        GameObject go = Instantiate(prefab);
        Gun gun = go.GetComponent<Gun>();
        return gun;
    }
}
