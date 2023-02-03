using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    private string version = "0.0.2";

    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //SceneManager.LoadScene("Title");
        AsyncOperation oper = SceneManager.LoadSceneAsync("Title");
        oper.completed += (obj) => {

            TitleMain titleMain = GameObject.FindObjectOfType<TitleMain>();
            titleMain.Init(this.version);

        };
    }
}
