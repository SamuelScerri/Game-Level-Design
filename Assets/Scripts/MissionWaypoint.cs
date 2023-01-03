using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public Canvas targetCanvas;
    public Image image;
    public GameObject target;
    public TextMeshProUGUI meter;

    public List<GameObject> enemy = new List<GameObject>();
    public GameObject[] enemyArray;

    public void Awake()
    {
        targetCanvas = GameObject.Find("TargetCanvas").GetComponent<Canvas>();
        target = GameObject.Find("Target");
        image = targetCanvas.transform.GetChild(0).GetComponent<Image>();
        meter = image.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    

    // Update is called once per frame
    void Update()
    {
        enemy.RemoveAll(GameObject => GameObject == null);
        /*if (SceneManager.GetActiveScene().name == "Student1-Level1Boss")
        {
            
            enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
            targetCanvas = GameObject.Find("TargetCanvas").GetComponent<Canvas>();
            target = GameObject.Find("Target");
            image = targetCanvas.transform.GetChild(0).GetComponent<Image>();
            meter = image.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            
        }*/
        /*target.SetActive(false);
        targetCanvas.gameObject.SetActive(false);
        if (enemy.Count == 0)
        {
            target.SetActive(true);
            targetCanvas.gameObject.SetActive(true);
        }*/

        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.transform.position);

        if (Vector3.Dot((target.transform.position - transform.position), transform.forward) < 0)
        {
            //Target is behind the player
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        image.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.transform.position, transform.position)).ToString() + "m";
    }
}
