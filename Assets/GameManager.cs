using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Win;
    public GameObject GameOver;
    public static GameManager Instance;
    // Start is called before the first frame update
    void Awake()
    {

        if (Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this); 
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void WinGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }

}
