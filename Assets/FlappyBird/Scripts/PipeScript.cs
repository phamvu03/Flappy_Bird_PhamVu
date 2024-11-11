using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float deathZone = -10;

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance.getIsPlaying())
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x < deathZone)
                Destroy(gameObject);
        }
    }
}
