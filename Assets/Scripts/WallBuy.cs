using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuy : MonoBehaviour
{
	private GameObject _player;
	private Interactable _interactor;

	private void Start()
	{
		_player = GameObject.FindWithTag("Player");
		_interactor = GetComponent<Interactable>();
		/*_interactor.weaponToAdd = GameObject.FindWithTag("Weapon");*/
		_interactor.executeEvent.AddListener(_player.GetComponent<Interactor>().WallBuy);
	}
}