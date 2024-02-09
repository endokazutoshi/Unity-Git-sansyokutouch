// BlockGameController.cs

using UnityEngine;
using UnityEngine.UI;

public class BlockGameController : MonoBehaviour
{
    public GameObject blockPrefab;  // �u���b�N���w��
    public Text scoreText;          // �N���b�N������|�C���g�����̂ł����\����������...
    public float gameDuration = 60f; // �������Ԃ�60�b

    private float timer;
    private int score;

    void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreText();
        InvokeRepeating("SpawnBlock", 0f, 1f); // 1�b���Ƃ�SpawnBlock���\�b�h���Ăяo��
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            GameOver();
        }
    }

    void SpawnBlock()
    {
        // Canvas��RectTransform���擾
        RectTransform canvasRect = GetComponent<RectTransform>();

        // �u���b�N�̃C���X�^���X�𐶐�
        GameObject block = Instantiate(blockPrefab, canvasRect);

        // �u���b�N��SpriteRenderer���A�^�b�`����Ă��Ȃ��ꍇ�̓A�^�b�`����
        if (block.GetComponent<SpriteRenderer>() == null)
        {
            block.AddComponent<SpriteRenderer>();
        }

        if(block.GetComponent<BoxCollider2D>() == null)
        {
            block.AddComponent<BoxCollider2D>();
        }
        // �u���b�N��RectTransform���擾
        RectTransform blockRect = block.GetComponent<RectTransform>();

        // �����_����X���W�ŏォ��u���b�N�������Ă���
        float spawnX = Random.Range(-canvasRect.sizeDelta.x / 2, canvasRect.sizeDelta.x / 2);
        blockRect.anchoredPosition = new Vector2(spawnX, canvasRect.sizeDelta.y / 2);

        // �u���b�N�̑��x�𐧌䂷��X�N���v�g���A�^�b�`
        if (block.GetComponent<BlockSpeedController>() == null)
        {
            block.AddComponent<BlockSpeedController>().fallSpeed = 5f; // �����ő��x��ݒ�
        }
    }


    public void BlockClicked()
    {
        score += 10; // �u���b�N���N���b�N������X�R�A�𑝉�
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        // �Q�[���I�[�o�[�̏����������ɒǉ�����i��: �X�R�A��\��������A���U���g��ʂɑJ�ڂ�����j
        Debug.Log("Game Over");
    }
}
