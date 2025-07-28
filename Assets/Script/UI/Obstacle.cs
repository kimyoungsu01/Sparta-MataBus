using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

   
    // 
    public float highPosY = 1;
    public float lowPosY = -1;

    // top과 buttom의 간격 사이즈를 얼마나 줄건지
    public float holeSizePosMin = 1;
    public float holeSizePosMax = 3;

    // top과 buttom의 간격의 폭을 얼마나 줄건지
    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    FlappyPlaneManager gameManager;

    private void Start()
    {
        gameManager = FlappyPlaneManager.instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount) 
    {
        float holeSize = Random.Range(holeSizePosMin,holeSizePosMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0,-halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY,highPosY);

        transform.position = placePosition;
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        
        if (player != null)
            gameManager.AddScore(1);

    }
    

}
