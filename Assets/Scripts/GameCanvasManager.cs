using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
    public int score;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        score = 0;
        UpdateScore(score);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void UpdateScore(int point)
    {
        score += point;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
