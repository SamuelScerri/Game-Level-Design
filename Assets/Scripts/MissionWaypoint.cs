using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public Image image;
    public Transform target;
    public TextMeshProUGUI meter;

    // Update is called once per frame
    void Update()
    {
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width- minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            //Target is behind the player
            if(pos.x< Screen.width / 2)
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
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
    }
}
