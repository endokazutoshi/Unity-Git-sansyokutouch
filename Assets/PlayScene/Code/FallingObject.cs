using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour
{
    public float firstSpeed = 0; // 初速度
    public float nextSpeed = 0; // 加速度
    public float maxCubeSpeed = 0; // 落下時の最高速度
    public float spawnInterval = 60.0f; // ブロックの生成間隔 (60秒ごと)
    public float totalTimeLimit = 300.0f; // 制限時間（秒） 300秒 = 5分

    private float currentSpeed; // 現在の速度
    private Color blockColor; // ブロックの色
    private float elapsedTime; // 経過時間

    static float minYPosition = -70f; // 画面外のY座標 → -70ぐらいに達したら消えるように設定

    // 追加: ターゲットのブロックの色
    public Color targetColor;

    // 追加: スコアの増加値
    public int scoreValue = 10;

    // 追加: スコアを表示するテキスト
    public Text scoreText;

    private bool isFalling = false; // 追加: 落下中かどうかのフラグ

    void Start()
    {
        currentSpeed = firstSpeed;
        elapsedTime = 0f;

        // ブロックの生成を開始
        InvokeRepeating("SpawnBlock", 0f, spawnInterval);
        // Colliderを無効にする
        GetComponent<Collider2D>().enabled = false;

        // 追加: スコアテキストの初期化
        UpdateScore();

        // 一番最初のブロック生成時に isFalling を true にする
        isFalling = true;
    }

    void UpdateScore()
    {
        // 追加: スコアテキストを更新
        scoreText.text = "Score: " + ScoreManager.Instance.score;
    }

    void SpawnBlock()
    {
        if (elapsedTime < totalTimeLimit)
        {
            // 初期位置と色をランダムに設定（他の同じ色のブロックと重ならないように調整）
            SetRandomPositionAndColor();
        }
        else
        {
            // 制限時間が経過したら生成を停止
            CancelInvoke("SpawnBlock");
        }
    }

    void SetRandomPositionAndColor()
    {
        float randomX, randomY;

        // 重なりを避けるためにループ
        do
        {
            randomX = Random.Range(150f, 700f);
            randomY = Random.Range(450f, 500f);
        } while (CheckOverlap(randomX, randomY));

        transform.position = new Vector3(randomX, randomY, 0);
        blockColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<SpriteRenderer>().color = blockColor;

        // Colliderを有効にする
        GetComponent<Collider2D>().enabled = true;
    }

    bool CheckOverlap(float x, float y)
    {
        // Colliderが重なっているかを確認
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(x, y), 1f);

        // 同じ色のブロックがある場合はtrue、ない場合はfalseを返す
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.GetComponent<FallingObject>()?.blockColor == blockColor)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        // 経過時間を更新
        elapsedTime += Time.deltaTime;

        // フレームごとにUIを落下させる
        Fall();

        // 画面外に出たらオブジェクトを破棄
        if (transform.position.y < minYPosition)
        {
            Debug.Log("Spawn new block at " + Time.time); // デバッグログを追加
            // スポーンさせる
            if (!isFalling) // 落下中でない場合にのみ新しいブロックを生成
            {
                SetRandomPositionAndColor();
                isFalling = true; // ブロックが再び落ち始める
            }
        }
    }

    public void OnMouseDown()
    {
        // ブロックがクリックされたときの処理
        if (isFalling && blockColor == targetColor)
        {
            IncrementScore();
        }

        // ブロックを削除
        Destroy(gameObject);
        isFalling = false; // ブロックがクリックされたので生成を再開
    }

    void IncrementScore()
    {
        ScoreManager.Instance.score += scoreValue;
        ScoreManager.Instance.UpdateScore(); // 追加: スコアを更新
        UpdateScore(); // 追加: スコアを更新
    }

    void Fall()
    {
        // 落下中でない場合は処理しない
        if (!isFalling)
        {
            return;
        }

        // 速度を初期化
        currentSpeed = firstSpeed;

        // 加速させる
        currentSpeed += nextSpeed * Time.deltaTime;

        // 最高速度を制限する
        currentSpeed = Mathf.Min(currentSpeed, maxCubeSpeed);

        // 落下させる速度と方向を設定
        Vector3 fallVector = new Vector3(0, -currentSpeed * Time.deltaTime, 0);

        // UIを移動させる
        transform.Translate(fallVector);
    }
}
