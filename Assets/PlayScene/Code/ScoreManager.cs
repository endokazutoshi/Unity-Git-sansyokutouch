using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int score = 0; // 静的変数としてスコアを保持
    public Text scoreText; // UI テキストオブジェクト

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScore(); // 初期化時にスコアを更新
    }

    public void UpdateScore()
    {
        // UI テキストにスコアを表示
        scoreText.text = "Score: " + score;
    }
}
