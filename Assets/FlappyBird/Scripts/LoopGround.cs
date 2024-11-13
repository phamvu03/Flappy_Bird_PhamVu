using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{

    public float speed = 1.3f;
    public float width = 6f;
    private SpriteRenderer SpriteRenderer;
    private Vector2 startSize;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(SpriteRenderer.size.x, SpriteRenderer.size.y);
    }
    void Update()
    {
        if (BirdController.instance.getIsPlaying())
        {
            SpriteRenderer.size =
                new Vector2(SpriteRenderer.size.x + speed * Time.deltaTime, SpriteRenderer.size.y);
            if (SpriteRenderer.size.x > width)
            {
                SpriteRenderer.size = startSize;
            }
        }
        
    }
}
