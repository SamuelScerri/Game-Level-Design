using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _healthPrefab;

	[SerializeField]
	private int _currentHealth;

	private void Start()
	{
		Instantiate(_healthPrefab);
	}

	private void TakeDamage(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth - amount, 0, 100);
	}

	public void Heal(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth + amount, 0, 100);
	}

	private void UpdateCounter()
	{
		
	}
}
