using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SaveLoadManager : MonoBehaviour
{
    SerializedData myserializedData;
    public void Start()
    {
        myserializedData = new SerializedData();
    }
    public void SaveMyData()
    {

        
        PlayerPrefs.SetString("ScoreData", GameData.highScore.ToString());
    }


    public void LoadMyData()
    {
        string loadedjson;
        if (PlayerPrefs.HasKey("ScoreData"))
        {
            loadedjson = PlayerPrefs.GetString("ScoreData");
            Debug.Log(loadedjson);
        }
    }
}
