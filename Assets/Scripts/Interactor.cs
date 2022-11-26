using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Interactor : MonoBehaviour
{
	[SerializeField]
	private float _pointsObtained;

	[SerializeField]
	private float _interactableDistance;

	[SerializeField]
	private LayerMask _interactableObjectLayers;

	[SerializeField]
	private GameObject _currentInteractableItem;

	[SerializeField]
	private GameObject _popupObject;

	private GameObject _popupObjectInstance;

	private void Start()
	{
		_popupObjectInstance = Instantiate(_popupObject);
	}

	void Update()
	{
		RaycastHit hitInformation;

		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInformation, _interactableDistance, _interactableObjectLayers))
			_currentInteractableItem = hitInformation.transform.gameObject;
		
		if (_currentInteractableItem)
		{
			Interactable reference = _currentInteractableItem.GetComponent<Interactable>();

			if (!reference.activated)
				_popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[E]\n" + reference.pointsNeededToExecute.ToString() + " Points Needed";
			else _popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unlocked";
			
			_popupObjectInstance.SetActive(true);

			if (Input.GetKeyDown("e") && _pointsObtained >= reference.pointsNeededToExecute && !reference.activated)
			{
				reference.executeEvent.Invoke();
				reference.activated = true;
			}
		}

		else _popupObjectInstance.SetActive(false);
		_currentInteractableItem = null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Cutscene")
			other.GetComponent<CutsceneManager>().StartCutscene();
	}
}
