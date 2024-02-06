using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int score = 0; // �ÓI�ϐ��Ƃ��ăX�R�A��ێ�
    public Text scoreText; // UI �e�L�X�g�I�u�W�F�N�g

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
        UpdateScore(); // ���������ɃX�R�A���X�V
    }

    public void UpdateScore()
    {
        // UI �e�L�X�g�ɃX�R�A��\��
        scoreText.text = "Score: " + score;
    }
}
