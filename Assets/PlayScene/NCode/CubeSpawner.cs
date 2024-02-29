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
    public float minX = -300.0f; // 左の制限
    public float maxX = 200.0f; // 右の制限

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
        // ランダムな横位置を計算（左右の範囲を制限）
        float randomX = Random.Range(minX, maxX);

        // Cubeの生成
        GameObject newCube = Instantiate(cubePrefab, canvasRect);

        // RectTransformの位置を設定
        RectTransform cubeRect = newCube.GetComponent<RectTransform>();
        cubeRect.anchoredPosition = new Vector2(randomX, cubeHeight);

        // 他の処理を追加...

        // Cubeに落下スクリプトをアタッチ
        CubeDropper dropper = newCube.AddComponent<CubeDropper>();
        dropper.FallSpeed = currentCubeFallSpeed; // 落下速度を設定
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
    // スコアを取得するメソッドを追加
    public int GetScore()
    {
        return score;
    }
}
