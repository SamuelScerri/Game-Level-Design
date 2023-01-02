using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWeapon : MonoBehaviour
{
    static SingleWeapon Instance;
    // Start is called before the first frame update
    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != GameObject.Find("P_LPSP_WEP_AR_01(Clone)").GetComponent<SingleWeapon>())
        {
            Destroy(GameObject.Find("P_LPSP_WEP_AR_01(Clone)"));
            GameObject.Find("P_LPSP_WEP_AR_01(Clone)").GetComponent<MagazineBehaviour>().SetAmmuniationTotal(+50);
        }
        else
        {
            Instance = GameObject.Find("P_LPSP_WEP_AR_01(Clone)").GetComponent<SingleWeapon>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
