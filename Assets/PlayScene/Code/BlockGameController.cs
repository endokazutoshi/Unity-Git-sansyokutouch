// BlockGameController.cs

// BlockGameController.cs

using UnityEngine;
using UnityEngine.UI;  // UnityEngine.UI.Text ���g�p���邽�߂ɕK�v��using�f�B���N�e�B�u��ǉ�

public class BlockGameController : MonoBehaviour
{
    public GameObject blockPrefab;
    public UnityEngine.UI.Text scoreText;  // ������UnityEngine.UI.Text���g�p����悤�ɏC��
    public float gameDuration = 60f;
    public float initialFallSpeed = 100f;
    private float spawnInterval = 1f;  // �����p�x
    private float timeSinceLastSpawn = 0f;  // �O�񐶐�����̌o�ߎ���

    private float timer;
    private int score;




void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreText();

        // �ŏ��� Cube �𐶐�
        Invoke("SpawnFirstBlock", 0f);

        // 5 �b��ɐV���� Cube �𐶐����ė���
        InvokeRepeating("SpawnBlock", 5f, spawnInterval);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timeSinceLastSpawn += Time.deltaTime;

        if (timer <= 0f)
        {
            GameOver();
        }
    }

    void SpawnFirstBlock()
    {
        SpawnBlock();
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

        // �u���b�N��RectTransform���擾
        RectTransform blockRect = block.GetComponent<RectTransform>();

        // �����_����X���W�ŏォ��u���b�N�������Ă���
        float spawnX = Random.Range(-canvasRect.sizeDelta.x / 2, canvasRect.sizeDelta.x / 2);
        blockRect.anchoredPosition = new Vector2(spawnX, canvasRect.sizeDelta.y / 2);

        // �u���b�N�̑��x�𐧌䂷��X�N���v�g���A�^�b�`
        BlockSpeedController speedController = block.GetComponent<BlockSpeedController>();
        if (speedController == null)
        {
            speedController = block.AddComponent<BlockSpeedController>();
        }

        // �X�s�[�h��ݒ�
        speedController.SetFallSpeed(initialFallSpeed + (score * 0.1f));  // �X�R�A�ɉ����đ��x���㏸
    }

    public void BlockClicked()
    {
        score += 10;
        UpdateScoreText();

        // �X�R�A���オ�邲�Ƃɐ������x���㏸
        spawnInterval = Mathf.Max(0.5f, spawnInterval - (score * 0.01f));
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
