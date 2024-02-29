// ScoreScene.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScene : MonoBehaviour
{
    public Text scoreText;
    public Button backButton; // �{�^����Inspector����֘A�t��

    void Start()
    { 
        DisplayScore();

        // �{�^���������ꂽ���̏�����ǉ�
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

       
    

    void DisplayScore()
    {
        // �X�R�A���擾
        int score = PlayerPrefs.GetInt("PlayerScore", 0);

        // UI�ȂǂŃX�R�A��\��
        scoreText.text = "Score: " + score.ToString();
    }
    public void OnBackButtonClicked()
    {
        // �{�^���������ꂽ����StageSelectScene�ɑJ��
        SceneManager.LoadScene("StageSelectScene");
    }
}
