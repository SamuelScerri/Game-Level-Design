using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _healthPrefab;

	[SerializeField]
	public int _currentHealth;

	public GameObject _healthUI;

	private Interactor interactor;

	private void Start()
	{
		interactor = GetComponent<Interactor>();
        _healthUI = Instantiate(_healthPrefab) as GameObject;
		UpdateUI();
		DontDestroyOnLoad(_healthUI);
    }

	private void SetHealth(int amount)
	{
		_currentHealth = amount;
		UpdateUI();
	}

	public void TakeDamage(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth - amount, 0, 100);
		if (_currentHealth <= 0) { SceneManager.LoadScene("YouLose"); Destroy(gameObject); }
		UpdateUI();
	}

	public void Heal(int amount)
	{
		_currentHealth = Mathf.Clamp(_currentHealth + amount, 0, 100);
		UpdateUI();
	}

	public void UpdateUI()
	{
		_healthUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Health: " + _currentHealth.ToString());
        _healthUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("Score: " + interactor._pointsObtained.ToString());
    }
}
