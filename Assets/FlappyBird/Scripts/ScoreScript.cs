using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    private int score;
    
    private int best = 0;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI finalTxt;
    public TextMeshProUGUI bestTxt;

    public int getScore()
    {
        return score;
    }
    public void UpdateScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        finalTxt.text = scoreTxt.text;
        UpdateBestScore();
    }
    public void UpdateBestScore()
    {
        if(score > PlayerPrefs.GetInt("BestScore"))
        {
            best = score;
            PlayerPrefs.SetInt("BestScore", score);
            bestTxt.text = best.ToString();
        }
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
    void Start()
    {
        scoreTxt.text =score.ToString();

        //Status: Fix Pending
        //bestTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        //Luu dc BestScore 1 lan, lan ke tiep BestScore bi luu thanh 0

        bestTxt.text = PlayerPrefs.GetInt("BestScore", best).ToString();
        UpdateBestScore();
    }
}
