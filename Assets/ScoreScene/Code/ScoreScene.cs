using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class ScoreScene : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public Button backButton; // ボタンをInspectorから関連付け

    public void Start()
    {
        DisplayScore();

        // ボタンがnullでない場合にイベントリスナーを追加
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
        else
        {
            UnityEngine.Debug.LogError("backButtonがnullです！"); // UnityEngine.Debugを明示的に指定
        }
    }

    void DisplayScore()
    {
        // スコアを取得
        int score = PlayerPrefs.GetInt("PlayerScore", 0);

        // UIなどでスコアを表示
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnBackButtonClicked()
    {
        // ボタンが押された時にStageSelectSceneに遷移
        SceneManager.LoadScene("StageSelectScene");
    }
}
