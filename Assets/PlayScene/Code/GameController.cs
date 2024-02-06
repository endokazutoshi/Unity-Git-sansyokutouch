using UnityEngine;

public class GameController : MonoBehaviour
{
    public FallingObject fallingObjectPrefab;

    void Start()
    {
        InvokeRepeating("SpawnFallingObject", 0f, 1f);
        Invoke("StopSpawning", 60f); // 60秒後にブロック生成を停止
    }

    void SpawnFallingObject()
    {
        // Instantiateで生成されたオブジェクトの参照を保持
        FallingObject fallingObject = Instantiate(fallingObjectPrefab);

        // nullチェックを行ってから処理を実行
        if (fallingObject != null)
        {
            // ここに処理を追加
        }
    }

    void StopSpawning()
    {
        CancelInvoke("SpawnFallingObject");
    }
}
