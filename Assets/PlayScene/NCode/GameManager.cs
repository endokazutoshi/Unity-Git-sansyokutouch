// GameManager.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private float timer = 0f;
    public float playTime = 30f;  // プレイ時間（秒）

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= playTime)
        {
            SaveScore();
            SceneManager.LoadScene("ScoreScene");
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnClick()
    {
        score += 10;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    public void MultiplyScore(int multiplier)
    {
        score *= multiplier;
        UpdateScoreText();
    }

    public void SubtractScore(int value)
    {
        score -= value;
        UpdateScoreText();
    }

    public void DivideScore(int divisor)
    {
        if (divisor != 0)
        {
            score /= divisor;
            UpdateScoreText();
        }
        else
        {
            Debug.LogWarning("Cannot divide by zero.");
        }
    }

    // 新しく追加したメソッド
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
}
