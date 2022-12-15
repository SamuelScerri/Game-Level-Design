using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public HealthManager healthManager;
    private void OnCollisionEnter(Collision collision)
    {
        healthManager = collision.gameObject.GetComponent<HealthManager>();
        if (collision.gameObject.tag == "Player")
        {
            healthManager.Heal(30);
            Destroy(gameObject);
        }
    }
}
