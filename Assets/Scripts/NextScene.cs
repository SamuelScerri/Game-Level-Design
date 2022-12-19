using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject nextSceneCollider;
    public GameObject waypoint;
    public List<GameObject> enemy = new List<GameObject>();
    public GameObject[] enemyArray;
    // Start is called before the first frame update
    void Start()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemy.AddRange(enemyArray);
        nextSceneCollider.SetActive(false);
        waypoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        if(enemy.Count == 0)
        {
            nextSceneCollider.SetActive(true);
            waypoint.SetActive(true);
        }
    }
}
