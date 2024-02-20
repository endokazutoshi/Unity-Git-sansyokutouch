// CubeSpawner.cs
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // CubeのPrefabをInspectorから関連付け
    public RectTransform canvasRect; // CanvasのRectTransformをInspectorから関連付け
    public float spawnInterval = 1.5f; // Cubeの生成間隔
    public float cubeHeight = 0f; // Cubeの高さ
    public float cubeFallSpeed = 5f; // Cubeの落下速度

    private float timer = 0f;
    private bool canSpawn = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            canSpawn = true;
        }

        // 一定時間ごとにCubeを生成
        if (canSpawn && timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        // Canvasの範囲を考慮してランダムな位置を計算
        Vector2 randomPosition = new Vector2(Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f),
                                             Random.Range(-canvasRect.rect.height / 2f, canvasRect.rect.height / 2f));

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
        dropper.fallSpeed = cubeFallSpeed; // ここで落下速度を設定
    }
}

