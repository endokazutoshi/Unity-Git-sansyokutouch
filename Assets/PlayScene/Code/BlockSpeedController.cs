// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    private float fallSpeed = 150f;

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
