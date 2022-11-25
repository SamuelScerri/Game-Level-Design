using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
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
			_popupObjectInstance.SetActive(true);

			if (Input.GetKeyDown("e"))
				_currentInteractableItem.GetComponent<Interactable>().executeEvent.Invoke();
		}

		else _popupObjectInstance.SetActive(false);
		_currentInteractableItem = null;
	}
}
