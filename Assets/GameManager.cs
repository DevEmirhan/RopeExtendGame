using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Start,
        Play,
        Win,
        Lose
    }
    public GameState gameState;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameState = GameState.Play;
    }
    public void WinGame()
    {
        gameState = GameState.Win;
        UIManager.Instance.Win();
        Debug.Log("You Win");
    }
    public void LoseGame()
    {
        gameState = GameState.Lose;
        UIManager.Instance.Lose();
        Debug.Log("You Lose");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }




}
