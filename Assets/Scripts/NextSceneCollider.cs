using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneCollider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(SceneManager.GetActiveScene().name == "Student1-Level1")
        {
            SceneManager.LoadScene("Student1-Level1Boss");
        }
    }
}
