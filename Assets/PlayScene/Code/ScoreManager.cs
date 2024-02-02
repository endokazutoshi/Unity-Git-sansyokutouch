using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // スコア変数

    private Text scoreText; // UI Text オブジェクト

    void Start()
    {
        // UI Text オブジェクトを取得
        scoreText = GetComponent<Text>();
        // スコアの初期値を表示
        UpdateScore();
    }

    // スコアを更新して表示
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
