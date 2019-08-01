using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneText : MonoBehaviour
{
    //public and private are scope modifiers.
    //public (the default) makes it accessible among all classes
    //private makes it specific to the class, and in this case the GO
    //private Text endText;

    public TMPro.TextMeshProUGUI endText;

    void Start()
    {
        bool hasWon = Player.hasWon; //Takes the value of itemCount from StatPLR and assigns it to the itemCount variable of this class each time the end scene is run.

        Debug.Log("EndSceneText.Start");
        endText = FindObjectOfType<TMPro.TextMeshProUGUI>(); // Object reference for Text component

        Debug.Log("EndSceneText: Player.hasWon = " + hasWon);

        if (hasWon)
        {
            endText.text = "Yay, you win!";
        }
        else
        {
            endText.text = "You lose, try again!";
        }
    }//Start
}//EndSceneText
