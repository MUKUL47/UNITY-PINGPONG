using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballMovement : MonoBehaviour {

    public float speed,x=0,y=0;
    Rigidbody2D r2b=null;
    bool right = false, started = false, gameOver = false;
    public Text p1, p2, Target, Winner, speed1;
    int p11 = 0, p22 = 0, rand = 0  ;

    public float timeLeft = 3;
	void Start () {
        r2b = GetComponent<Rigidbody2D>();
        rand = UnityEngine.Random.Range(3, 10);
        Target.text = "Target is " + rand ;
    }

    void Update()
    {
        print(rand + " " + p1+" "+p2);
        if (timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
            
            
        }
       
        if (timeLeft < 0)
        {
            started = true;
            
            
        }
        
        print(timeLeft+" "+started+" "+speed);
        if (started)
        {
            if (right) r2b.velocity = new Vector2(x * speed, y * speed);

            else r2b.velocity = new Vector2(speed * -x, -y * speed);
           
        }/// print(x + " L " + y);


    }
    
    void OnTriggerEnter2D(Collider2D Object)
    {   
        //when hit right or left
        if (Object.gameObject.name == "Right")
        {
            x = -1 * x;
            if (++p11 == rand && !gameOver) { Winner.text = "Player 1 won !!!"; Target.text = ""; gameOver = true; }
            p1.text = p11 + "";
            speed = (float)5; speed1.text = "Speed " + speed;

        }
        else if (Object.gameObject.name == "Left")
        {
            x = -x;
            if (++p22 == rand && !gameOver) { Winner.text = "Player 2 won !!!"; Target.text = ""; gameOver = true; }
            p2.text = p22 + "";
            speed = (float)5; speed1.text = "Speed " + speed;

        }

        //when hit a bar
        if (Object.gameObject.name == "BarRight")
        {

            speed += (float)10; speed1.text = "Speed " + speed;
            right = false; 
            changeDirection1(Object);
        }
        else if (Object.gameObject.name == "BarLeft")
        {
            speed += (float)10; speed1.text = "Speed " + speed;
            right = true; 
            changeDirection1(Object);
        }

        // when hit top ya bottom

        if (Object.gameObject.name == "Top")
        {
            y = -y;            
        }
        if (Object.gameObject.name == "Bottom")
        {
            y = -1*y;
        }


    }

        public void changeDirection1(Collider2D Object)
        {
        x = 1;
        if ((r2b.transform.position.y-Object.gameObject.transform.position.y) > 0)
        {
            if (right) y = (float)(r2b.transform.position.y - Object.gameObject.transform.position.y);
            else y = -(float)(r2b.transform.position.y - Object.gameObject.transform.position.y);
        }
        else if((r2b.transform.position.y - Object.gameObject.transform.position.y) < 0)
        {
            if (right) y = (float)(r2b.transform.position.y - Object.gameObject.transform.position.y);
            else y = -(float)(r2b.transform.position.y - Object.gameObject.transform.position.y);
        }
        else
        {
            y = 0;
        }
    }
    }