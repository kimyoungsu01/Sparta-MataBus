using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPotal : MonoBehaviour
{
    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("탈출 감지! 씬 전환합니다.");
            SceneManager.LoadScene("MainScene");
        }
    }
}
