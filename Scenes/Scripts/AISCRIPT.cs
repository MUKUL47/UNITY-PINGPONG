using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISCRIPT : MonoBehaviour {

    public GameObject Ball;
    Rigidbody2D barRight;
    float y = 0;

    void Start () {
        barRight = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float POS = (barRight.transform.position.y -Ball.transform.position.y);
        print(POS);
        if (POS>3 || POS<-3)
        {
            if (POS > 2.5)
            {
                barRight.velocity = new Vector2(0, y-1) * 12;
            }
            else
            {
                barRight.velocity = new Vector2(0, y+1) * 12;
            }
        }
    }
}
