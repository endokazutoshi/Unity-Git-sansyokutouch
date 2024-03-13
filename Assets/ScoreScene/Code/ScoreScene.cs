using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class ScoreScene : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public Button backButton; // �{�^����Inspector����֘A�t��

    public void Start()
    {
        DisplayScore();

        // �{�^����null�łȂ��ꍇ�ɃC�x���g���X�i�[��ǉ�
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
        else
        {
            UnityEngine.Debug.LogError("backButton��null�ł��I"); // UnityEngine.Debug�𖾎��I�Ɏw��
        }
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
