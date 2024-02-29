// ScoreScene.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScene : MonoBehaviour
{
    public Text scoreText;
    public Button backButton; // ボタンをInspectorから関連付け

    void Start()
    { 
        DisplayScore();

        // ボタンが押された時の処理を追加
        backButton.onClick.AddListener(OnBackButtonClicked);
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
