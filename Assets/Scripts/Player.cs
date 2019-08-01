using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float minX = 5.0f; //minimum spawn proximity to player start
    float maxX = 150.0f; //maximum spawn proximity to player start

    public GameObject[] Allies;
    private Vector3 PlayerPosition;
    private GameObject player_prefab; //you don't need to assign this to anything in the inspector
    private GameObject ally_prefab;

    public bool isOnGround;
    public bool hitAlly;
    public static bool hasWon;
    public Object player;
    public float g = 0.0f; //set to 0 by default
    public static int allies = 0; //counts the number of allies you've collected (akin to score)
    
    


    
    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerImage = GameObject.FindGameObjectWithTag("PlayerImage");
        int i = Random.Range(0, Allies.Length);
        PlayerPosition = PlayerImage.transform.position;
        Destroy(PlayerImage);
        player_prefab = Instantiate(GameObjectRandomPicker.random(i, Allies), PlayerPosition, Quaternion.identity);
        player_prefab.tag = "PlayerImage";
        player_prefab.transform.parent = this.transform;



        float x = transform.position.x;
        float y = transform.position.y;
        hitAlly = false;
        Vector2 jumpPoint = new Vector2(0, 0);
        isOnGround = true;
        allies = 0;
        Debug.Log("start");

        Spawn();
    }//Start



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.15f, g, 0.0f);

        float x = transform.position.x;
        float y = transform.position.y;

        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera"); //object reference for Main Camera
        mainCamera.transform.position = new Vector3(x, 5.0f, -1.0f);

        isOnGround = (y == 2.0f);



        if (y > 2.0f)
        {
            g -= 0.025f; //g = g - 0.1f;
        }
        else
        {
            transform.position = new Vector2(x + 0.032f, 2.0f);
            g = 0.0f; //stops the y-translation
        }

        if (Input.GetKeyDown("space") && isOnGround)
        {
            Jump();
        }

        if (hitAlly)
        {
            GameObject ally = GameObject.FindGameObjectWithTag("Ally"); //object reference for allies
            ally.transform.position = new Vector2(transform.localPosition.x - 2.0f, transform.localPosition.y); //puts the ally behind the player.
        }//if an ally GO has been hit, make it follow the player


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
            hasWon = false; //the player has hit an obstacle and died
            Destroy(player);
            SceneLoader.GameOver();
        }//ObstacleCollisions

        if (collision.gameObject.tag == "Ally")
        {
            Debug.Log("Collision detected : " + collision + " : Ally");
            hitAlly = true;
            allies++; //ally collected!
            Debug.Log("Number of allies = " + allies);
        }//AllyCollisions

        if (collision.gameObject.tag == "Goal")
        {
            hasWon = true; //the player has hit the goal and won
            SceneLoader.GameOver(); //Loads the end scene.
        }

    }//OnCollisionEnter2D



    void Spawn()
    {
        int range = Random.Range(0, Allies.Length);

        for (int a = range; a <= Allies.Length; a++) //runs the following instructions for each ally
        {
            //player_prefab.tag = "Ally";
            float randomX = Random.Range(minX, maxX); //x-coordinates to spawn at
            Vector2 spawnX = new Vector2(randomX, transform.position.y);
            int i = Random.Range(0, Allies.Length);
            Instantiate(GameObjectRandomPicker.random(i, Allies), spawnX, Quaternion.identity);
        }
        
    }//Spawn


    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }















}//Player
