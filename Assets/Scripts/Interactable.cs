using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	public bool activated;

	[SerializeField]
	public int pointsNeededToExecute;

	[SerializeField]
	public UnityEvent executeEvent;

	[SerializeField]
	public GameObject weaponToAdd;

	[SerializeField]
	public string textPopup;

	Interactor interactor;

    private void Start()
    {
		interactor= GameObject.Find("Player").GetComponent<Interactor>();
		if(gameObject.name == "WallBuy")
		{
            interactor.interactable = this;
        }
		
        /*weaponToAdd= GameObject.Find("P_LPSP_WEP_AR_01").GetComponent<GameObject>();*/
        /*executeEvent.AddListener(GameObject.Find("Player").GetComponent<Interactor>().WallBuy);*/
    }
}
