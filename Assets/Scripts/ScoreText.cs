using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI gameText;
    
    // Update is called once per frame
    void Update()
    {
        int allies = Player.allies;
        gameText = FindObjectOfType<TMPro.TextMeshProUGUI>();
        gameText.text = ("ALLIES: " + allies);
    }//Update







}//ScoreText
