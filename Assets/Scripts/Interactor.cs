using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using InfimaGames.LowPolyShooterPack;

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


	[SerializeField]
	public Interactable interactable;

	[SerializeField]
	public GameObject inventory;

	[SerializeField]
	public Inventory weaponInventory;

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
			{
				if (reference.pointsNeededToExecute > 0)
					_popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[E]\n" + reference.pointsNeededToExecute.ToString() + " Points Needed To: " + reference.textPopup;
				else _popupObjectInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[E]\n" + reference.textPopup;
			}
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

	public void WallBuy()
    {
        interactable.weaponToAdd.SetActive(false);
        interactable.weaponToAdd.transform.parent = inventory.transform;
        weaponInventory.Init(0);
        weaponInventory.weapons[0].gameObject.SetActive(true);
    }
}
