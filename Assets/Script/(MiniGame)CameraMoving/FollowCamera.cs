using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour
{
    public static FollowCamera Instance;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Transform target;
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Time.timeScale = 0f;
            return;
        }

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }

}


