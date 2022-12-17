using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
	public PauseManager pauseManager;

	[SerializeField]
	public float _pointsObtained;

	[SerializeField]
	private float _interactableDistance;

	[SerializeField]
	private LayerMask _interactableObjectLayers;

	[SerializeField]
	private GameObject _currentInteractableItem;

	[SerializeField]
	private GameObject _popupObject;

	private GameObject _popupObjectInstance;

	[SerializeField]
	public Interactable interactable;

	[SerializeField]
	public GameObject inventory;

	[SerializeField]
	public Inventory weaponInventory;

	[SerializeField]
	public HealthManager healthManager;

	private void Start()
	{
		_popupObjectInstance = Instantiate(_popupObject);
		//DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if(pauseManager._isPaused == false)
		{
            RaycastHit hitInformation;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInformation, _interactableDistance, _interactableObjectLayers))
                _currentInteractableItem = hitInformation.transform.gameObject;

            if (_currentInteractableItem)
            {
                Interactable reference = _currentInteractableItem.GetComponent<Interactable>();

                if (!reference.activated)
                {
                    if (reference.pointsNeededToExecute > 0)
                        _popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[E]\n" + reference.pointsNeededToExecute.ToString() + " Points Needed To: " + reference.textPopup;
                    else _popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[E]\n" + reference.textPopup;
                }
                else _popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unlocked";

                _popupObjectInstance.SetActive(true);

                if (Input.GetKeyDown("e") && _pointsObtained >= reference.pointsNeededToExecute && !reference.activated)
                {
					GameData.score = GameData.score - reference.pointsNeededToExecute;
					_pointsObtained = _pointsObtained - reference.pointsNeededToExecute;
                    reference.executeEvent.Invoke();
                    reference.activated = true;
                    healthManager.UpdateUI();
                }
            }
            else _popupObjectInstance.SetActive(false);
            _currentInteractableItem = null;
        }
	}

	public void IncreaseScore(float scorevalue)
	{
        GameData.score += scorevalue;
		_pointsObtained += scorevalue;
		/*Debug.Log("Score: " + GameData.score);*/
		Debug.Log("Points Obtained: " + _pointsObtained);
		healthManager.UpdateUI();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Cutscene")
			other.GetComponent<CutsceneManager>().StartCutscene();
	}

	public void WallBuy()
    {
		if(pauseManager._isPaused == false)
		{
            interactable.weaponToAdd.SetActive(false);
            interactable.weaponToAdd.transform.parent = inventory.transform;
            weaponInventory.Init(0);
            weaponInventory.weapons[0].gameObject.SetActive(true);
			healthManager.UpdateUI();
        }
    }
}
