using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreScript.instance.UpdateScore();
    }
}
