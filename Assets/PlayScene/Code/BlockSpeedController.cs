// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    public float fallSpeed = 5f; // �u���b�N�������Ă��鑬�x

    void Awake()
    {
        // SpriteRenderer �R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�͒ǉ�����
        if (GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>();
        }

        // Rigidbody2D �R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�͒ǉ�����
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        
        if(GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        
        // �u���b�N�̑��x��ݒ�
        rb.velocity = new Vector2(0f, -fallSpeed);
    }

    void OnMouseDown()
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
