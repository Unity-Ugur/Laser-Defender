using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSession : MonoBehaviour
{
    private int gameScore = 0;

    // Awake is called before the first frame start
    void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetGameScore()
    {
        return gameScore;
    }

    public void AddToGameScore(int scoreValue)
    {
        gameScore += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}