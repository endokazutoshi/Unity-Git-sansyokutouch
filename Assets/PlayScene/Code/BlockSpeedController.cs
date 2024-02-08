// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    public float fallSpeed = 5f; // ブロックが落ちてくる速度

    void Start()
    {
        // Rigidbody2D コンポーネントを取得
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Rigidbody2D コンポーネントが存在するか確認
        if (rb != null)
        {
            // ブロックの速度を設定
            rb.velocity = new Vector2(0f, -fallSpeed);
        }
        else
        {
            // Rigidbody2D コンポーネントがアタッチされていない場合はエラーメッセージを表示
            Debug.LogError("Rigidbody2D is missing on the game object: " + gameObject.name);
        }
    }
}

