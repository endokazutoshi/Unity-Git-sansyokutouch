// BlockGameController.cs

using UnityEngine;
using UnityEngine.UI;

public class BlockGameController : MonoBehaviour
{
    public GameObject blockPrefab;  // ブロックを指定
    public Text scoreText;          // クリックしたらポイントがつくのでそれを表示させるやつ...
    public float gameDuration = 60f; // 制限時間は60秒

    private float timer;
    private int score;

    void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateScoreText();
        InvokeRepeating("SpawnBlock", 0f, 1f); // 1秒ごとにSpawnBlockメソッドを呼び出す
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
        // CanvasのRectTransformを取得
        RectTransform canvasRect = GetComponent<RectTransform>();

        // ブロックのインスタンスを生成
        GameObject block = Instantiate(blockPrefab, canvasRect);

        // ブロックにSpriteRendererがアタッチされていない場合はアタッチする
        if (block.GetComponent<SpriteRenderer>() == null)
        {
            block.AddComponent<SpriteRenderer>();
        }

        if(block.GetComponent<BoxCollider2D>() == null)
        {
            block.AddComponent<BoxCollider2D>();
        }
        // ブロックのRectTransformを取得
        RectTransform blockRect = block.GetComponent<RectTransform>();

        // ランダムなX座標で上からブロックが落ちてくる
        float spawnX = Random.Range(-canvasRect.sizeDelta.x / 2, canvasRect.sizeDelta.x / 2);
        blockRect.anchoredPosition = new Vector2(spawnX, canvasRect.sizeDelta.y / 2);

        // ブロックの速度を制御するスクリプトをアタッチ
        if (block.GetComponent<BlockSpeedController>() == null)
        {
            block.AddComponent<BlockSpeedController>().fallSpeed = 5f; // ここで速度を設定
        }
    }


    public void BlockClicked()
    {
        score += 10; // ブロックをクリックしたらスコアを増加
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        // ゲームオーバーの処理をここに追加する（例: スコアを表示したり、リザルト画面に遷移したり）
        Debug.Log("Game Over");
    }
}
