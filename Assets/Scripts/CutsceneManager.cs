using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
	[SerializeField]
	private int _level;
	private bool _startedCutscene;
	private bool _startedTransition;

	private Animation _animation;
	private GameObject _camera;

	private Image _transitionImage;

	private GameObject _player;

	private void Start()
	{
		_animation = GetComponent<Animation>();
		_camera = transform.GetChild(0).gameObject;

		_transitionImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
		_transitionImage.color = Color.black;

		_camera.SetActive(false);

		_player = GameObject.FindWithTag("Player");
	}

	public void StartCutscene()
	{
		_startedTransition = true;

		Destroy(GameObject.FindWithTag("UI"));
	}

	public void Update()
	{
		if (_startedTransition)
			_transitionImage.color = Color.Lerp(_transitionImage.color, Color.black, Time.deltaTime * 8);
		else _transitionImage.color = Color.Lerp(_transitionImage.color, new Color(0, 0, 0, 0), Time.deltaTime * 8);
			
		//On End Animation, Switch Level
		if (_startedCutscene && !GetComponent<Animation>().isPlaying)
			_startedTransition = true;

		if (_transitionImage.color.a >= .99f)
		{
			if (_startedCutscene)
			{
				_player.SetActive(true);
				SceneManager.LoadScene(_level, LoadSceneMode.Single);
			}
				

			else
			{
				//Remove Player & UI
				_player.SetActive(false);
				
				_startedCutscene = true;
				_startedTransition = false;

				_camera.SetActive(true);
				_animation.Play();
			}
		}
	}
}
