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

    private bool isPaused = false;
    public GameManager()
    {
        this.isPaused = false;
    }
    public bool getIsPaused()
    {
        return this.isPaused;
    }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) 
            && BirdController.instance.getIsPlaying())
            if (!isPaused)
                GamePaused();
            else
                GameContinue();
    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        gameStartCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
        bird.SetActive(true);
        BirdController.instance.setIsPlaying(true);
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        BirdController.instance.setIsPlaying(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GamePaused()
    {
        Time.timeScale = 0f;
        isPaused = !isPaused;
        gamePlayCanvas.SetActive(false);
        gamePausedCanvas.SetActive(true);
    }
    public void GameContinue()
    {
        Time.timeScale = 1.0f;
        isPaused = !isPaused;
        gamePlayCanvas.SetActive(true);
        gamePausedCanvas.SetActive(false);
        BirdController.instance.setIsPlaying(true);
    }
}
