using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject nextSceneCollider;
    public GameObject target;
    public Canvas targetCanvas;
    public List<GameObject> enemy = new List<GameObject>();
    public GameObject[] enemyArray;
    // Start is called before the first frame update
    void Start()
    {
        targetCanvas = GameObject.Find("TargetCanvas").GetComponent<Canvas>();
        target = GameObject.Find("Target");
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemy.AddRange(enemyArray);
        nextSceneCollider.SetActive(false);
        target.SetActive(false);
        targetCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        GameObject.Find("ObjectiveTitle").GetComponent<TextMeshProUGUI>().SetText("");
        GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("");
        if (Input.GetKey(KeyCode.Tab))
        {
            GameObject.Find("ObjectiveTitle").GetComponent<TextMeshProUGUI>().SetText("Objectives:");
            if(enemy.Count == 0)
            {
                GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("Go to the next objective");
            }
            else
            {
                GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("Kill All Zombies (" + enemy.Count + "/" + enemyArray.Length + ")");
            }
        }
        if (enemy.Count == 0)
        {
            target.SetActive(true);
            targetCanvas.gameObject.SetActive(true);
            nextSceneCollider.SetActive(true);
        }
    }
}
