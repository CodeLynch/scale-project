using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Win;
    public GameObject GameOver;

    public static GameManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this); 
    }

    public void LoseGame()
    {
            Time.timeScale = 0;
            GameOver.SetActive(true);   
    }
    public void WinGame()
    {
        Time.timeScale = 0;
        Win.SetActive(true);
    }

}
