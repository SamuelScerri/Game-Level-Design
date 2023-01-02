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
    public GameObject cheatCanvas;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        cheatCanvas.SetActive(false);
        enemy.AddRange(enemyArray);
    }

    private void CheatCanvas()
    {
        pauseManager._isPaused= true;
        cheatCanvas.SetActive(true);
    }

    public void KillAllEnemies()
    {
        pauseManager._isPaused = false;
        for(int i = 0; i < enemyArray.Length; i++) { enemyArray[i].gameObject.GetComponent<Enemy>().Die(); }
        cheatCanvas.SetActive(false);
    }

    public void SelfDestroy() { SceneManager.LoadScene("YouLose"); }

    public void IncreaseAmmo()
    {
        pauseManager._isPaused = false;
        cheatCanvas.SetActive(false);
        character.equippedWeaponMagazine.SetAmmuniationTotal(character.equippedWeaponMagazine.GetAmmunitionTotal() + 100);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        if (Input.GetKeyDown(KeyCode.C)) { CheatCanvas(); }
    }
}
