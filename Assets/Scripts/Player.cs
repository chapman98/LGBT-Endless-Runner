using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isOnGround;
    public Object player;
    public float g = 0.0f; //set to 0 by default
    static int playerIndex = 0;
    static int currentIndex = 0;
    int allyIndex;




    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
        currentIndex = 0;
        allyIndex = currentIndex++; //unique id
        Debug.Log("start");
        Debug.Log("allyIndex = " + allyIndex);
    }//Start



    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(0.096f, g, 0.0f);
        float x = transform.position.x;
        float y = transform.position.y;
        //transform.position = new Vector2(x + 0.032f, y + g);
        isOnGround = (y == 2.0f);



        if (y > 2.0f)
        {
            g -= 0.015f; //g = g - 0.1f;
        }
        else
        {
            transform.position = new Vector2(x + 0.032f, 2.0f);
            g = 0.0f; //stops the y-translation
        }

        if (allyIndex == playerIndex && Input.GetKeyDown("space") && isOnGround)
        {
            Jump();
        }


    }//Update



    void Jump()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        g = 0.5f;


    }//Jump



    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collision detected : " + collision + " : Obstacle");
            Destroy(player);
            SceneLoader.GameOver();
        }//ObstacleCollisions

        if (collision.gameObject.tag == "Ally")
        {
            Debug.Log("Collision detected : " + collision + " : Ally");
            playerIndex++;
            Debug.Log("playerIndex = " + playerIndex);
        }//AllyCollisions



    }//OnCollisionEnter2D



















}//Player
