using UnityEngine;
using UnityEngine.UI; // こちらを追加

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText; // TextオブジェクトをInspectorから関連付け

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Textに現在の得点を表示
        scoreText.text = "Score: " + score.ToString();
    }

    // クリックされたときの処理
    public void OnClick()
    {
        // 得点を増やす処理（例: クリックごとに10点追加）
        score += 10;

        // 得点を表示する
        UpdateScoreText();

        // 他の処理を追加...
    }
}
