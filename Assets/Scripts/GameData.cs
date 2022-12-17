using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public abstract class GameData : MonoBehaviour
{
    private static float _score;
    private static float _highScore;

    public static float score
    {
        get { return _score; }
        set { _score = value; }
    }

    public static float highScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }
}