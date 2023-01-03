using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
	/*[SerializeField]
	private int _level;
	private bool _startedCutscene;
	private bool _startedTransition;

	private Animation _animation;
	private GameObject _camera;

	private Image _transitionImage;*/

	private GameObject _player;
	private GameObject canvas;
    private GameObject healthCanvas;

    private void Start()
	{
		/*_animation = GetComponent<Animation>();
		_camera = transform.GetChild(0).gameObject;

		_transitionImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
		_transitionImage.color = Color.black;

		_camera.SetActive(false);*/
		healthCanvas = GameObject.Find("Health(Clone)");
		healthCanvas.SetActive(false);
		_player = GameObject.FindWithTag("Player");
		_player.SetActive(false);
		canvas = GameObject.Find("P_LPSP_UI_Canvas(Clone)");
        canvas.SetActive(false);


        if (SceneManager.GetActiveScene().name == "Student1-Level1BossCutscene")
		{
			StartCoroutine(EndLevel1BossCutscene());
		}
		else if (SceneManager.GetActiveScene().name == "Lvl2Cutscene")
        {
            StartCoroutine(EndLevel2Cutscene());
        }
    }

	public IEnumerator EndLevel1BossCutscene()
	{
        
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Student1-Level1Boss");
		_player.SetActive(true);
        canvas.SetActive(true);
		healthCanvas.SetActive(true);
    }

    public IEnumerator EndLevel2Cutscene()
    {

        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Lvl2");
        _player.SetActive(true);
        canvas.SetActive(true);
        healthCanvas.SetActive(true);
    }

    /*public void StartCutscene()
	{
		_startedTransition = true;

		//Destroy(GameObject.FindWithTag("UI"));
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
	}*/
}
