using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject nextSceneCollider;
    public List<GameObject> enemy = new List<GameObject>();
    public GameObject[] enemyArray;
    // Start is called before the first frame update
    void Start()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemy.AddRange(enemyArray);
        
        GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("");
        GameObject.Find("ObjectiveTitle").GetComponent<TextMeshProUGUI>().SetText("");
        /*nextSceneCollider.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        
        if (enemy.Count == 0)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("Go to the next objective");
            }
            else
            {
                GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("");
            }
                
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            GameObject.Find("ObjectiveTitle").GetComponent<TextMeshProUGUI>().SetText("Objectives:");
            GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("Kill All Zombies (" + enemy.Count + "/" + enemyArray.Length + ")");
        }
        else
        {
            GameObject.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().SetText("");
            GameObject.Find("ObjectiveTitle").GetComponent<TextMeshProUGUI>().SetText("");
        }
    }
}
