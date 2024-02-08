// BlockSpeedController.cs

using UnityEngine;

public class BlockSpeedController : MonoBehaviour
{
    public float fallSpeed = 5f; // �u���b�N�������Ă��鑬�x

    void Start()
    {
        // Rigidbody2D �R���|�[�l���g���擾
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Rigidbody2D �R���|�[�l���g�����݂��邩�m�F
        if (rb != null)
        {
            // �u���b�N�̑��x��ݒ�
            rb.velocity = new Vector2(0f, -fallSpeed);
        }
        else
        {
            // Rigidbody2D �R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�̓G���[���b�Z�[�W��\��
            Debug.LogError("Rigidbody2D is missing on the game object: " + gameObject.name);
        }
    }
}

