using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public abstract class GameData : MonoBehaviour
{
    private static int _score;
    private static int _highScore;

    public static int score
    {
        get { return _score; }
        set { _score = value; }
    }

    public static int highScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }
}