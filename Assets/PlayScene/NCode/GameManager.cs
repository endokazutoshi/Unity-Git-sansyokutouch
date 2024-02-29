// GameManager.cs
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
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

    // �V�����ǉ��������\�b�h
    public int GetScore()
    {
        return score;
    }
}
