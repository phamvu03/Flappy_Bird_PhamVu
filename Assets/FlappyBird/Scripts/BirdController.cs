using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public Rigidbody2D rigidbody;
    public Animator birdAnimator;
    //private GameManager gameManager = new GameManager();

    [SerializeField] private float gravity = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private bool isPlaying = true;
    public void setIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
    }
    public bool getIsPlaying()
    {
        return isPlaying;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
        //gameManager.GameOver();
        isPlaying = false;
        birdAnimator.enabled = false;
    }
    void Start()
    {
        if(instance == null)
            instance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        birdAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.y * rotationSpeed);    
    }
    void Update()
    {
        bool isPaused = GameManager.Instance.getIsPaused();
        Debug.Log("1--------------");
        Debug.Log(isPlaying);
        Debug.Log("2--------------");
        Debug.Log(isPaused);
        //if (gameManager.isPaused)
        
        if (!isPaused)
        {
            if (isPlaying)
            {
                if (Input.GetButtonDown("Fire1"))
                    rigidbody.velocity = Vector2.up * gravity;
            }
        }
    }
}
