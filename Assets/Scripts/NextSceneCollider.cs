using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class NextSceneCollider : MonoBehaviour
{
    /*public GameObject camera;*/

    /*private void Start()
    {
        camera.GetComponent<MissionWaypoint>().enemyArray = camera.GetComponent<MissionWaypoint>().enemy.ToArray();
        camera.GetComponent<MissionWaypoint>().enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (SceneManager.GetActiveScene().name == "Level3Boss")
            { camera.GetComponent<MissionWaypoint>().enemyArray = GameObject.FindGameObjectsWithTag("FinalBoss"); }
        camera.GetComponent<MissionWaypoint>().enemy.AddRange(camera.GetComponent<MissionWaypoint>().enemyArray);
        camera.GetComponent<MissionWaypoint>().targetCanvas = GameObject.Find("TargetCanvas").GetComponent<Canvas>();
        camera.GetComponent<MissionWaypoint>().target = GameObject.Find("Target");
        camera.GetComponent<MissionWaypoint>().image = camera.GetComponent<MissionWaypoint>().targetCanvas.transform.GetChild(0).GetComponent<Image>();
        camera.GetComponent<MissionWaypoint>().meter = camera.GetComponent<MissionWaypoint>().image.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }*/

    /*private void Update()
    {
        camera.GetComponent<MissionWaypoint>().enemy.RemoveAll(GameObject => GameObject == null);
        if (camera.GetComponent<MissionWaypoint>().enemy.Count == 0)
        {
            camera.GetComponent<MissionWaypoint>().target.SetActive(true);
            camera.GetComponent<MissionWaypoint>().targetCanvas.gameObject.SetActive(true);
        }
        else
        {
            camera.GetComponent<MissionWaypoint>().target.SetActive(false);
            camera.GetComponent<MissionWaypoint>().targetCanvas.gameObject.SetActive(false);
        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        //GameObject.FindWithTag("Player").SetActive(false);

        if (SceneManager.GetActiveScene().name == "Student1-Level1")
        {
            SceneManager.LoadScene("Student1-Level1BossCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "Student1-Level1Boss")
        {
            SceneManager.LoadScene("Lvl2Cutscene");
        }
        else if (SceneManager.GetActiveScene().name == "Lvl2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level3BossCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "Level3Boss")
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
