using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public GameObject endPanel;
    public Text nowScore;
    public Text bestScore;


    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.Log("restart text is null");

        if (scoreText == null)
            Debug.Log("score text is null");

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart() 
    {
        int score = FlappyPlaneManager.instance.currentScore;

        if (PlayerPrefs.HasKey("bestscore"))
        {
            int best = PlayerPrefs.GetInt("bestscore");

            if (best < score)
            {
                // 현재 점수를 최고점수에 저장한다
                PlayerPrefs.SetInt("bestscore", score);
                best = score;
            }

            bestScore.text = best.ToString();
            nowScore.text = score.ToString();
        }

        else
        {
            PlayerPrefs.SetInt("bestscore", score);
            bestScore.text = score.ToString();
            nowScore.text = score.ToString();
        }

        endPanel.SetActive(true);

        restartText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}

    


