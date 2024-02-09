// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    public float fallSpeed = 5f; // ブロックが落ちてくる速度

    void Awake()
    {
        // SpriteRenderer コンポーネントがアタッチされていない場合は追加する
        if (GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>();
        }

        // Rigidbody2D コンポーネントがアタッチされていない場合は追加する
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        
        if(GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        
        // ブロックの速度を設定
        rb.velocity = new Vector2(0f, -fallSpeed);
    }

    void OnMouseDown()
    {
        // ブロックがクリックされたときの処理
        BlockGameController gameController = FindObjectOfType<BlockGameController>();
        if (gameController != null)
        {
            gameController.BlockClicked();
        }

        // ブロックを削除する（または非アクティブにする）
        Destroy(gameObject);
    }
}
