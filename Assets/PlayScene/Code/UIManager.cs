using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // ブロックのPrefab
    public RectTransform canvasRect; // CanvasのRectTransform
    public float spawnInterval = 2f; // ブロックを生成する間隔
    private float timer = 0f;

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
        // CanvasのRectTransformからランダムな位置を取得
        float spawnX = Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f);
        float spawnY = canvasRect.rect.height / 2f; // Canvasの上端に固定
        float spawnZ = 0f;

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, spawnZ);

        // Prefabからブロックを生成し、Canvasの子オブジェクトに設定
        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        fallingObject.transform.SetParent(canvasRect, false); // Canvas内での相対的な座標を維持

        // マウスでクリックしたときにオブジェクトを破棄できるようにする
        fallingObject.AddComponent<BoxCollider2D>();
    }
}
