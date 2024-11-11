using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    private int score;
    public TextMeshProUGUI scoreTxt;
    public int getScore()
    {
        return score;
    }
    public void UpdateScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            score++;
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text =score.ToString();
    }
}
