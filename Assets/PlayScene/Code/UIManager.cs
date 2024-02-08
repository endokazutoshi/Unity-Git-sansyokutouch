using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // ブロックのPrefab
    public RectTransform canvasRect; // CanvasのRectTransform
    public float spawnInterval = 2f; // ブロックを生成する間隔
    private float timer = 0f;

    // 修正: ブロックの初速度と最高速度
    public float firstSpeed = 5f;
    public float maxCubeSpeed = 15f;

    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // 一定時間ごとにブロックを生成
        if (timer >= spawnInterval)
        {
            SpawnFallingObject();
            timer = 0f; // タイマーをリセット
        }
    }

    void SpawnFallingObject()
    {
        // ブロックを生成する位置をCanvas内のランダムな位置に変更
        float spawnX = Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f);
        float spawnY = canvasRect.rect.height / 2f;

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Prefabからブロックを生成し、Canvasの子オブジェクトに設定
        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        fallingObject.transform.SetParent(canvasRect, false); // Canvas内での相対的な座標を維持

        // 修正: ブロックの速度コンポーネントを取得し初速度と最高速度を設定
        FallingObject fallingObjectComponent = fallingObject.GetComponent<FallingObject>();
        if (fallingObjectComponent != null)
        {
            fallingObjectComponent.firstSpeed = firstSpeed;
            fallingObjectComponent.maxCubeSpeed = maxCubeSpeed;
        }

        // マウスでクリックしたときにオブジェクトを破棄できるようにする
        fallingObject.AddComponent<BoxCollider2D>();
    }
}
