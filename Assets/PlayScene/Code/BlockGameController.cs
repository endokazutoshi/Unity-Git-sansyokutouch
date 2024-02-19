// BlockGameController.cs

using UnityEngine;
using UnityEngine.UI;

public class BlockGameController : MonoBehaviour
{
    public GameObject blockPrefab;
    public Text scoreText;
    public float gameDuration = 60f;
    public float initialFallSpeed = 100f;
    private float spawnInterval = 1f;
    private float timeSinceLastSpawn = 0f;

    private float timer;
    private int score;

    void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreText();

        Invoke("SpawnFirstBlock", 0f);
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
        RectTransform canvasRect = GetComponent<RectTransform>();

        GameObject block = Instantiate(blockPrefab, canvasRect);

        if (block.GetComponent<SpriteRenderer>() == null)
        {
            block.AddComponent<SpriteRenderer>();
        }

        RectTransform blockRect = block.GetComponent<RectTransform>();
        float spawnX = Random.Range(-canvasRect.sizeDelta.x / 2, canvasRect.sizeDelta.x / 2);
        blockRect.anchoredPosition = new Vector2(spawnX, canvasRect.sizeDelta.y / 2);

        // ブロックにBlockSpeedControllerがアタッチされていない場合はアタッチ
        BlockSpeedController speedController = block.GetComponent<BlockSpeedController>();
        if (speedController == null)
        {
            speedController = block.AddComponent<BlockSpeedController>();
            speedController.SetFallSpeed(initialFallSpeed + (score * 0.1f));
        }
        else
        {
            speedController.SetFallSpeed(initialFallSpeed + (score * 0.1f));
        }
    }

    public void BlockClicked()
    {
        score += 10;
        UpdateScoreText();
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
