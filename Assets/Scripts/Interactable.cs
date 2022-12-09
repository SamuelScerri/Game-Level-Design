using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	public bool activated;

	[SerializeField]
	public float pointsNeededToExecute;

	[SerializeField]
	public UnityEvent executeEvent;

	[SerializeField]
	public GameObject weaponToAdd;
}
