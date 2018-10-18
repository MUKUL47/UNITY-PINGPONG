using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barsMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    bool mov = false;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //-7.82 4.92
        float Y = 0;


        Y = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(0, Y) * 20;

    }
}
