using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player { get; private set; }

    [SerializeField] private int currentWaveIndex = 0;

    private void Awake()
    {
        Instance = this;

        player = FindObjectOfType<PlayerController>();
        player.init(this);
    }

    public void StartGame() 
    {
        StrartNextWave();
    }

    void StrartNextWave() 
    {
        currentWaveIndex += 1;
    }

    public void EndOfWave() 
    {
        StrartNextWave();
    }

    public void GameOver() 
    {
        //enemyManager.StopWave();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
           StartGame();
        }
    }
}


