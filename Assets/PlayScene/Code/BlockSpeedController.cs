// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    private float fallSpeed = 150f;
    private bool canClick = true;

    void Awake()
    {
        if (GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>();
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        // ブロックの速度を設定
        rb.velocity = new Vector2(0f, -fallSpeed);
    }

    void OnMouseDown()
    {
        if (canClick)
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

    void Update()
    {
        // 最初の5秒間はクリックを受け付けない
        if (Time.timeSinceLevelLoad < 5f)
        {
            canClick = false;
        }
        else
        {
            canClick = true; // 5秒後にクリックを受け付けるようにする
        }
    }

    public void SetFallSpeed(float speed)
    {
        fallSpeed = speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // ブロックの速度を設定
            rb.velocity = new Vector2(0f, -fallSpeed);
        }
    }
}
