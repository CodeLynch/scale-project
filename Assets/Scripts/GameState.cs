using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // in the event the names or the tags change
    private string itemTag = "Cage";
    private string endScene = "GameOverScene";
    public static bool playerWin = false;

    // Update is called once per frame
    void Update()
    {
        GameObject[] cages = GameObject.FindGameObjectsWithTag(itemTag);
        int itemCount = cages.Length;

        if (itemCount == 0)
        {
            GameOver(true);
        }
    }

    void GameOver(bool win)
    {
        playerWin = win;
        SceneManager.LoadScene(endScene);
    }
}
