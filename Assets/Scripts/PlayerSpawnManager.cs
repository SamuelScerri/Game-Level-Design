using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (SceneManager.GetActiveScene().name == "Student1-Level1Boss")
        {
            player.transform.position = new Vector3(0,0,0);
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
            player = Instantiate(playerPrefab) as GameObject;

        player.transform.position = transform.position;
    }
}