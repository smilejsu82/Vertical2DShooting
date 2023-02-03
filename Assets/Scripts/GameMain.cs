using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public GameObject[] gunPrefabs;

    public PlayerController player;

    //Awake - Init - Start - Update 
    public void Init(GameEnums.eGunType selectedGunType)
    {
        //���� ����� 
        Gun gun = this.CreateGun(selectedGunType);

        //�÷��̾�� ���� ���� �Ѵ� 
        this.player.Init(gun);
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
