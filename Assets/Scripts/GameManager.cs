using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)    //SINGLETON PATTERN
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        /*GetComponent<SaveLoadManager>().LoadMyData();*/
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "YouWin")
        {
            if (GameData.score >= GameData.highScore)
            {
                GameData.highScore = GameData.score;
                GetComponent<SaveLoadManager>().SaveMyData();
            }
        }
    }
}
