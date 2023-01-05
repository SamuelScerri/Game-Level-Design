using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GenericStats : MonoBehaviour
{
	private Canvas _canvas;
	private TextMeshProUGUI _fpsCounter, _levelName, _zombiesCounter;

	private Interactor _interactor;

	private void Start()
	{
		_fpsCounter = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		_levelName = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		_zombiesCounter = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

		_interactor = GameObject.FindWithTag("Player").GetComponent<Interactor>();

		_canvas = GetComponent<Canvas>();

		_levelName.text = "Level Name: " + SceneManager.GetActiveScene().name;
	}

	private void Update()
	{
		_fpsCounter.text = "FPS: " + (1.0f / Time.smoothDeltaTime).ToString();
		_zombiesCounter.text = "Zombies Killed: " + _interactor.zombiesKilled;

		_canvas.enabled = Input.GetKey(KeyCode.K) ? true : false;
	}
}
