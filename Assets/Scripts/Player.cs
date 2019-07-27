using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isOnGround = false;
    public Object player;
    public float g = 0.0f; //set to 0 by default



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }//Start



    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector2(x + 0.032f, y + g);
        isOnGround = (y == 2.0f);

        if (Input.GetKeyDown("space") && isOnGround)
        {
          Jump();
        }

        //g = -1.0f;



    }//Update



    void Jump()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        //transform.position = new Vector2(x + 0.016f, y + 2.0f);
        g = 0.1f;


    }//Jump



    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision detected: " + coll);
        Destroy(player);
    }//OnCollisionEnter2D



















}//Player
