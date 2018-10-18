using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarRight : MonoBehaviour
{
    Rigidbody2D r1;
    void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Y = Input.GetAxis("Horizontal");
        r1.velocity = new Vector2(0, Y) * 20;

    }
}
