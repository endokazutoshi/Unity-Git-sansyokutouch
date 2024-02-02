using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // �X�R�A�ϐ�

    private Text scoreText; // UI Text �I�u�W�F�N�g

    void Start()
    {
        // UI Text �I�u�W�F�N�g���擾
        scoreText = GetComponent<Text>();
        // �X�R�A�̏����l��\��
        UpdateScore();
    }

    // �X�R�A���X�V���ĕ\��
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
