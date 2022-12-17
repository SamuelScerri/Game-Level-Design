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

        myserializedData.ser_highscore = GameData.highScore;

        string jsontosave = JsonUtility.ToJson(myserializedData);
        Debug.Log(jsontosave);
        PlayerPrefs.SetString("SnowballData", jsontosave);
    }


    public void LoadMyData()
    {
        string loadedjson;
        if (PlayerPrefs.HasKey("SnowballData"))
        {
            loadedjson = PlayerPrefs.GetString("SnowballData");
            myserializedData = JsonUtility.FromJson<SerializedData>(loadedjson);
            GameData.highScore = myserializedData.ser_highscore;
        }
    }
}
