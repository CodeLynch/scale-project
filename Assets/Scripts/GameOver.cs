using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameState.playerWin)
        {
            resultText.text = "YOU WIN!";
        }
        else resultText.text = "YOU DIED";
    }
}