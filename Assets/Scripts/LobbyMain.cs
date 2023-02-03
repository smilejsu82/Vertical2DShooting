using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMain : MonoBehaviour
{
    public Button btnStart;
    public Button btnGun1;  //�⺻ 
    public Button btnGun2;  //��Ƽ 
    public Text textSelectedGun;

    private GameEnums.eGunType selectedGunType;

    public GameEnums.eGunType SelectedGunType
    {
        set {
            this.selectedGunType = value;
            this.textSelectedGun.text = string.Format("{0}�� �����߽��ϴ�.", this.selectedGunType);
        }
    }

    void Start()
    {
        this.SelectedGunType = GameEnums.eGunType.Default;

        this.btnStart.onClick.AddListener(() => {
            Debug.Log("���� ����");
            //���õ� ���� Ÿ�� ��� 
            Debug.Log(this.selectedGunType);
            
            AsyncOperation oper =  SceneManager.LoadSceneAsync("Game");
            oper.completed += (obj) => {
                //Game���� �ε�� 
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
                gameMain.Init(this.selectedGunType);    
            };

        });

        this.btnGun1.onClick.AddListener(() => {
            Debug.Log("�⺻ ���� ���� �߽��ϴ�.");
            this.SelectedGunType = GameEnums.eGunType.Default;
        });

        this.btnGun2.onClick.AddListener(() => {
            Debug.Log("��Ƽ ���� ���� �߽��ϴ�.");
            this.SelectedGunType = GameEnums.eGunType.Multiple;
        });
    }
}
