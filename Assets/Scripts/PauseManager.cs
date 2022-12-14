using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private Image _pauseScreen;
    /*public Button pauseButton;*/
    public Button resumeButton;
    /*public GameObject gObjPauseButton;*/
    public GameObject gObjResumeButton;

    /*public Button pauseButton;*/
    public Button quitButton;
    /*public GameObject gObjPauseButton;*/
    public GameObject gObjQuitButton;

    //The method signature of how the event listeners/subscibers need to have
    public delegate void PauseDelegate();

    //The event that is triggered when the p button is pressed
    public event PauseDelegate Pause_State_Changed;

    //The variable storing the pause state (True / False)
    public bool _isPaused;

     //Get all UI objects
    GameObject[] _uiItems;

    //The getter and setter in one place
    public bool Paused
    {
        get => _isPaused;
        set
        {
            if (_isPaused != value)
            {
                //Updated isPaused variable
                _isPaused = value;
                //Game Pause
                Time.timeScale = value ? 0 : 1;
                //Triggering the event
                Pause_State_Changed?.Invoke();
            }

        }
    }

    private void Start()
    {
        _uiItems = GameObject.FindGameObjectsWithTag("UI");

        _pauseScreen = GameObject.Find("PauseCanvas").GetComponent<Image>();

        //Subscribing
        //Adding the method PauseListener to listen to Pause_State_Changed
        Pause_State_Changed += PauseListener;

        /*pauseButton.onClick.AddListener(Pause);*/
        resumeButton.onClick.AddListener(Pause);
        quitButton.onClick.AddListener(Quit);
    }
    private void OnDestroy()
    {
        //Unsubscribing
        //Removing the method PauseListener to stop listening to Pause_State_Changed
        Pause_State_Changed -= PauseListener;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        //Change pause state
        Paused = !Paused;
        //Update the UI
        _pauseScreen.enabled = Paused;


    }

    //The listener/subscibed method, listening to the event
    private void PauseListener()
    {
        Debug.Log(Paused ? "Game is currently Paused" : "Game is currently active");
        if (Paused == true)
        {
            /*gObjPauseButton.SetActive(false);*/
            gObjResumeButton.SetActive(true);
            gObjQuitButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible= true;

            foreach (GameObject item in _uiItems)
            {
                item.SetActive(false);
            }
        }
        else
        {
            /*gObjPauseButton.SetActive(true);*/
            gObjResumeButton.SetActive(false);
            gObjQuitButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            foreach (GameObject item in _uiItems)
            {
                item.SetActive(true);
            }
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Home");
    }

}
