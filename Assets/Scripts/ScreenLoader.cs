using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void WaitAndLoad()
    {
        StartCoroutine(LoadGameOverScene());
    }
     IEnumerator LoadGameOverScene()
    {
        yield return  new WaitForSeconds(1f);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}