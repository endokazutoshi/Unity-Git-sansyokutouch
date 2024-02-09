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

        // �u���b�N�̑��x��ݒ�
        rb.velocity = new Vector2(0f, -fallSpeed);
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            // �u���b�N���N���b�N���ꂽ�Ƃ��̏���
            BlockGameController gameController = FindObjectOfType<BlockGameController>();
            if (gameController != null)
            {
                gameController.BlockClicked();
            }

            // �u���b�N���폜����i�܂��͔�A�N�e�B�u�ɂ���j
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // �ŏ���5�b�Ԃ̓N���b�N���󂯕t���Ȃ�
        if (Time.timeSinceLevelLoad < 5f)
        {
            canClick = false;
        }
        else
        {
            canClick = true; // 5�b��ɃN���b�N���󂯕t����悤�ɂ���
        }
    }

    public void SetFallSpeed(float speed)
    {
        fallSpeed = speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // �u���b�N�̑��x��ݒ�
            rb.velocity = new Vector2(0f, -fallSpeed);
        }
    }
}
