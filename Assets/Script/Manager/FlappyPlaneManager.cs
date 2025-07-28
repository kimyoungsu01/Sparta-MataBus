using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneManager : MonoBehaviour
{
    static FlappyPlaneManager flappyPlaneManager;

    public static FlappyPlaneManager instance { get { return flappyPlaneManager; } }

    public int currentScore { get; set; }

    UIManager uIManager;

    public UIManager UIManager { get { return uIManager; } }

    private void Awake()
    {
        flappyPlaneManager = this;
        uIManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uIManager.UpdateScore(0);
    }

    public void GameOver() 
    {
        Debug.Log("Game Over");
        uIManager.SetRestart();
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score) 
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);
        uIManager.UpdateScore(currentScore);
    }
}
