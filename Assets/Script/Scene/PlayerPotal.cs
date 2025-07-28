using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPotal : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("portal"))
        {
            Debug.Log("Portal ���� ����! �� ��ȯ�մϴ�.");
            SceneManager.LoadScene("FlappyPlaneScene");

        }
    }
}
