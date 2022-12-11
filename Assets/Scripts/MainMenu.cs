using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton, quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }
    public void Play()
    {
        SceneManager.LoadScene("Student1-Level1");

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Bye");
    }
}
