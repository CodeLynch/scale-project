using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            QuitGame();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            LoadScene("SampleScene");
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
