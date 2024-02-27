// CubeSpawner.cs
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // CubeのPrefabをInspectorから関連付け
    public RectTransform canvasRect; // CanvasのRectTransformをInspectorから関連付け
    public float minSpawnInterval = 1.0f; // Cubeの生成最小間隔
    public float maxSpawnInterval = 3.0f; // Cubeの生成最大間隔
    public float cubeHeight = 0f; // Cubeの高さ
    public float initialCubeFallSpeed = 5f; // 初期のCubeの落下速度
    public float maxCubeFallSpeed = 15f; // 最大のCubeの落下速度

    private float timer = 0f;
    private float spawnInterval = 0f;
    private float currentCubeFallSpeed;

    private int score = 0;

    void Start()
    {
        CalculateNewSpawnInterval();
        currentCubeFallSpeed = initialCubeFallSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
            CalculateNewSpawnInterval();
        }

        // スコアが上がるにつれて落下スピードを上げる
        currentCubeFallSpeed = Mathf.Min(initialCubeFallSpeed + (score * 0.1f), maxCubeFallSpeed);
    }

    void CalculateNewSpawnInterval()
    {
        // ランダムな間隔を計算
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnCube()
    {
        // Canvasの範囲を考慮してランダムな位置を計算
        Vector2 randomPosition = GetRandomPosition();

        // Cubeの生成
        GameObject newCube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);

        // 他の処理を追加...

        // 生成されたCubeがCanvas内に収まるようにする
        RectTransform cubeRect = newCube.GetComponent<RectTransform>();
        cubeRect.SetParent(canvasRect);
        cubeRect.anchoredPosition = randomPosition;

        // Cubeの高さを設定
        Vector3 cubePosition = newCube.transform.position;
        cubePosition.y = cubeHeight;
        newCube.transform.position = cubePosition;

        // Cubeに落下スクリプトをアタッチ
        CubeDropper dropper = newCube.AddComponent<CubeDropper>();
        dropper.fallSpeed = currentCubeFallSpeed; // 落下速度を設定
    }

    Vector2 GetRandomPosition()
    {
        // ランダムな位置を計算
        Vector2 randomPosition = new Vector2(Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f),
                                             Random.Range(-canvasRect.rect.height / 2f, canvasRect.rect.height / 2f));

        // 生成されたCubeが他のCubeと重なっていないかチェック
        Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, 1f); // 1fは適切な半半径
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Cube"))
            {
                // 他のCubeと重なっている場合、再帰的に位置を計算
                return GetRandomPosition();
            }
        }

        return randomPosition;
    }

    // スコアが上がったときに呼ばれるメソッド
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
