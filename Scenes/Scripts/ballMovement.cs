using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ballMovement : MonoBehaviour {

    public float speed,x=0,y=0;
    Rigidbody2D r2b=null;
    bool right = false, started = true, gameOver = false;
    public Text p1, p2, Target, Winner, speed1;
    int p11 = 0, p22 = 0, rand = 0  ;
    float T = 2;
    public float timeLeft = 3;

    Scene currentScene;




    void Start () {
        currentScene = SceneManager.GetActiveScene();
        r2b = GetComponent<Rigidbody2D>();
        if (started)
        {
            rand = (int)UnityEngine.Random.Range(3,10);
            Target.text = "Target is " + rand;
            started = false;
        }
    }

    void Update()
    {
        r2b = GetComponent<Rigidbody2D>();

        if (timeLeft>0)  timeLeft -= Time.deltaTime;   

        if (timeLeft<0)
        {
            
            if (right) r2b.velocity = new Vector2(x * speed, y * speed);

            else r2b.velocity = new Vector2(speed * -x, -y * speed);
           
        }

        if (gameOver)
        {
            
            if (T > 0) T -= Time.deltaTime;

            if (T < 0)
            {              
                if(currentScene.name=="PvP") SceneManager.LoadScene("PvP");
                
                else SceneManager.LoadScene("PvAI");

            }
                

        }


    }
    
    void OnTriggerEnter2D(Collider2D Object)
    {
        int t = 5;
        //when hit right or left
        if (Object.gameObject.name == "Right")
        {
            x = -1 * x;
            if (++p11 == rand && !gameOver) { Winner.text = "Player 1 won !!!"; Target.text = ""; gameOver = true;
               
            }
            p1.text = p11 + "";
            speed1.text = "Speed " + speed;

        }
        else if (Object.gameObject.name == "Left")
        {
            x = -x;
            if (++p22 == rand && !gameOver) {
                if (currentScene.name == "PvP") Winner.text = "Player 2 won !!!";
                else Winner.text = "Computer won !!!";
                Target.text = ""; gameOver = true;
               
            }
            p2.text = p22 + "";
            speed1.text = "Speed " + speed;

        }

        //when hit a bar
        if (Object.gameObject.name == "BarRight")
        {

            speed += (float).5; speed1.text = "Speed " + speed;
            right = false; 
            changeDirection1(Object);
        }
        else if (Object.gameObject.name == "BarLeft")
        {
            speed += (float).5; speed1.text = "Speed " + speed;
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
        float POS = (r2b.transform.position.y - Object.gameObject.transform.position.y);
        if (POS > 0)
        {
            if (right) y = (float)POS;
            else y = -(float)POS;
        }
        else if(POS < 0)
        {
            if (right) y = (float)POS;
            else y = -(float)POS;
        }
        else
        {
            y = 0;
        }
    }
    }