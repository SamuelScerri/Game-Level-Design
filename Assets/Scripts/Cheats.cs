using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InfimaGames.LowPolyShooterPack;

public class Cheats : MonoBehaviour
{
    public GameObject[] enemyArray;
    public List<GameObject> enemy = new List<GameObject>();
    public PauseManager pauseManager;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemy.AddRange(enemyArray);
    }

    private void CheatCanvas()
    {
        pauseManager._isPaused= true;
        GameObject.Find("CheatCanvas").SetActive(true);
    }

    public void KillAllEnemies()
    {
        pauseManager._isPaused = false;
        for(int i = 0; i < enemyArray.Length; i++) { enemyArray[i].gameObject.GetComponent<Enemy>().Die(); }
        GameObject.Find("CheatCanvas").SetActive(false);
    }

    public void SelfDestroy() { SceneManager.LoadScene("YouLose"); }

    public void IncreaseAmmo()
    {
        pauseManager._isPaused = false;
        GameObject.Find("CheatCanvas").SetActive(false);
        character.equippedWeaponMagazine.SetAmmuniationTotal(character.equippedWeaponMagazine.GetAmmunitionTotal() + 100);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        if (Input.GetKeyDown(KeyCode.C)) { CheatCanvas(); }
    }
}
