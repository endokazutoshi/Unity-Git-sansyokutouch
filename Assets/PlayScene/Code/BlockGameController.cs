// BlockGameController.cs

// BlockGameController.cs

using UnityEngine;
using UnityEngine.UI;  // UnityEngine.UI.Text を使用するために必要なusingディレクティブを追加

public class BlockGameController : MonoBehaviour
{
    public GameObject blockPrefab;
    public UnityEngine.UI.Text scoreText;  // ここもUnityEngine.UI.Textを使用するように修正
    public float gameDuration = 60f;
    public float initialFallSpeed = 100f;
    private float spawnInterval = 1f;  // 生成頻度
    private float timeSinceLastSpawn = 0f;  // 前回生成からの経過時間

    private float timer;
    private int score;




void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreText();

        // 最初の Cube を生成
        Invoke("SpawnFirstBlock", 0f);

        // 5 秒後に新しい Cube を生成して流す
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
        // CanvasのRectTransformを取得
        RectTransform canvasRect = GetComponent<RectTransform>();

        // ブロックのインスタンスを生成
        GameObject block = Instantiate(blockPrefab, canvasRect);

        // ブロックにSpriteRendererがアタッチされていない場合はアタッチする
        if (block.GetComponent<SpriteRenderer>() == null)
        {
            block.AddComponent<SpriteRenderer>();
        }

        // ブロックのRectTransformを取得
        RectTransform blockRect = block.GetComponent<RectTransform>();

        // ランダムなX座標で上からブロックが落ちてくる
        float spawnX = Random.Range(-canvasRect.sizeDelta.x / 2, canvasRect.sizeDelta.x / 2);
        blockRect.anchoredPosition = new Vector2(spawnX, canvasRect.sizeDelta.y / 2);

        // ブロックの速度を制御するスクリプトをアタッチ
        BlockSpeedController speedController = block.GetComponent<BlockSpeedController>();
        if (speedController == null)
        {
            speedController = block.AddComponent<BlockSpeedController>();
        }

        // スピードを設定
        speedController.SetFallSpeed(initialFallSpeed + (score * 0.1f));  // スコアに応じて速度を上昇
    }

    public void BlockClicked()
    {
        score += 10;
        UpdateScoreText();

        // スコアが上がるごとに生成速度を上昇
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
