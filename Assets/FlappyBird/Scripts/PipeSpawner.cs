using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;

    public float upperPosi = 2f;
    public float lowerPosi = -1f;
    [SerializeField] private float spawnTime = 1f;
    private float timer;

    private void SpawnPipe()
    {
        Vector3 pipePos = transform.position + new Vector3(0, Random.Range(lowerPosi, upperPosi), 0);
        GameObject instancePipe = Instantiate(pipe, pipePos, Quaternion.identity);
    }

    void Update()
    {
        if (BirdController.instance.getIsPlaying())
        {
            if (timer > spawnTime)
            {
                SpawnPipe();
                timer = 0;
            }
            spawnTime = 1 * (1 - 0.05f * ScoreScript.instance.getScore());
            timer += Time.deltaTime;
        }
    }
}
