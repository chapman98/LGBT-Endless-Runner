using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRandomPicker : MonoBehaviour
{




    public void Start()
    {
        
    }

    /*public static Sprite Srandom(int i, Sprite[] players)
    {
        i = Random.Range(0, players.Length);
        Sprite player = players[i];
        return player;
    }

    public static var Arandom(int i, var[] players)
    {
        i = Random.Range(0, players.Length);
        var player = players[i];
        return player;
    }*/

    public static GameObject random(int i, GameObject[] Allies)
    {
        //i = Random.Range(0, Allies.Length);
        var person = Allies[i];
        return person;

    }

}
