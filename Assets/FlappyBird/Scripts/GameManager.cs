using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameStartCanvas;
    public GameObject gamePlayCanvas;
    public GameObject gameOverCanvas;
    public GameObject gamePausedCanvas;
    public GameObject bird;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        Time.timeScale = 1.0f;
    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        gameStartCanvas.SetActive(false);
        gamePausedCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
        bird.SetActive(true);
        BirdController.instance.setIsPlaying(true);
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        BirdController.instance.setIsPlaying(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GamePaused()
    {
        Time.timeScale = 0f;
        gamePlayCanvas.SetActive(false);
        gamePausedCanvas.SetActive(true);
        BirdController.instance.setIsPlaying(false);
    }
    private void Start()
    {
        
    }
}
