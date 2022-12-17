using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScene : MonoBehaviour
{
    [SerializeField] private Button goHomeButton;
    TextMeshProUGUI scoreText, highScoreText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        goHomeButton.onClick.AddListener(GoHome);
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + GameData.score.ToString();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        GameData.highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + GameData.highScore.ToString();
        /*Debug.Log("HighScore: "+ GameData.highScore);*/
        if (GameData.score >= GameData.highScore)
        {
            GameData.highScore = GameData.score;
            highScoreText.text = "High Score: " + GameData.highScore.ToString();

            PlayerPrefs.SetInt("HighScore", GameData.highScore);
            PlayerPrefs.Save();
        }
    }
    public void GoHome()
    {
        GameData.score = 0;
        SceneManager.LoadScene("Home");
    }
}
