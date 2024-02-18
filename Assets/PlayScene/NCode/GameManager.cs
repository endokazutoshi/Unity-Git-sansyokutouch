using UnityEngine;
using UnityEngine.UI; // �������ǉ�

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText; // Text�I�u�W�F�N�g��Inspector����֘A�t��

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Text�Ɍ��݂̓��_��\��
        scoreText.text = "Score: " + score.ToString();
    }

    // �N���b�N���ꂽ�Ƃ��̏���
    public void OnClick()
    {
        // ���_�𑝂₷�����i��: �N���b�N���Ƃ�10�_�ǉ��j
        score += 10;

        // ���_��\������
        UpdateScoreText();

        // ���̏�����ǉ�...
    }
}
