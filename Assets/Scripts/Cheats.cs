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
    public Canvas cheatCanvas;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<Character>();
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemy.AddRange(enemyArray);
        cheatCanvas.enabled = false;
    }

    private void CheatCanvas()
    {
        cheatCanvas.enabled = true;
    }

    public void KillAllEnemies()
    {
        for(int i = 0; i < enemyArray.Length; i++) { enemy[i].gameObject.GetComponent<Enemy>().Die(); }
        cheatCanvas.enabled = false;
    }

    public void SelfDestroy() { SceneManager.LoadScene("YouLose"); }

    public void IncreaseAmmo()
    {
        cheatCanvas.enabled = false;
        character.equippedWeaponMagazine.SetAmmuniationTotal(character.equippedWeaponMagazine.GetAmmunitionTotal() + 100);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        if (Input.GetKeyDown(KeyCode.C)) { CheatCanvas(); }
    }
}
