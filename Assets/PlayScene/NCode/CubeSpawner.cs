// CubeSpawner.cs
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public RectTransform canvasRect;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float cubeHeight = 0f;
    public float initialCubeFallSpeed = 5f;
    public float maxCubeFallSpeed = 15f;
    public float minX = -300.0f;
    public float maxX = 200.0f;

    private float timer = 0f;
    private float spawnInterval = 0f;

    private int score = 0;

    void Start()
    {
        CalculateNewSpawnInterval();
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
    }

    void CalculateNewSpawnInterval()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnCube()
    {
        float randomX = Random.Range(minX, maxX);

        GameObject newCube = Instantiate(cubePrefab, canvasRect);

        RectTransform cubeRect = newCube.GetComponent<RectTransform>();
        cubeRect.anchoredPosition = new Vector2(randomX, cubeHeight);

        CubeDropper dropper = newCube.GetComponent<CubeDropper>();

        // CubeDropperのFallSpeedプロパティに初期速度を設定
        dropper.FallSpeed = initialCubeFallSpeed;

        // 他の処理を追加...
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public int GetScore()
    {
        return score;
    }
}
