using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindWithTag("Player").transform.position = transform.position;
    }
}
