using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _healthPrefab;

	[SerializeField]
	public int _currentHealth;

	public GameObject _healthUI;

	private void Start()
	{
		_healthUI = Instantiate(_healthPrefab) as GameObject;
		UpdateUI();
	}

	private void SetHealth(int amount)
	{
		_currentHealth = amount;
		UpdateUI();
	}

	private void TakeDamage(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth - amount, 0, 100);
		UpdateUI();
	}

	public void Heal(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth + amount, 0, 100);
		UpdateUI();
	}

	private void UpdateUI()
	{
		_healthUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Health: " + _currentHealth.ToString());
	}
}
