using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Rigidbody itemRb;
    public float dropForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemRb.GetComponent<Rigidbody>();
        itemRb.AddForce(Vector3.up * dropForce, ForceMode.Impulse);
    }
}
