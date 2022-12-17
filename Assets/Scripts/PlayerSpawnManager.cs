using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
            Instantiate(playerPrefab);

        else player.transform.position = transform.position;
    }
}