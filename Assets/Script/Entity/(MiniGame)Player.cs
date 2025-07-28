using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 0.03f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlip = false;

    public bool godMode = false;

    FlappyPlaneManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FlappyPlaneManager.instance;

          animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded _rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0) 
            {

                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                { 
                  gameManager.RestartGame();
                }
            }

            else { deathCooldown -= Time.deltaTime; }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            { 
              isFlip = true;
            }
        
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return; 
        
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlip) 
        { 
            velocity.y += flapForce;
            isFlip = false;
        
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }

}
