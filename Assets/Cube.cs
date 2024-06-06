using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.forward * 100f + transform.up * 45f) * 18f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
