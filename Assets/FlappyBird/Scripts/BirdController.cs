using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public Rigidbody2D rigidbody;

    [SerializeField] private float gravity = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private bool isDead = false;
    private bool isPlaying = true;
    public void setIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
    }
    public bool getIsPlaying()
    {
        return isPlaying;
    }
    public bool getIsDead()
    {
        return isDead;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
        isPlaying = false;
    }
    void Start()
    {
        if(instance == null)
            instance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.y * rotationSpeed);
        //Debug.Log(isPlaying);
    }
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetButtonDown("Fire1"))
                rigidbody.velocity = Vector2.up * gravity;
        }
    }
}
