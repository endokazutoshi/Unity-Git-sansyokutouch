// BlockClickHandler.cs

using UnityEngine;

public class BlockClickHandler : MonoBehaviour
{
    // �u���b�N���N���b�N���ꂽ���̏���
    private void OnMouseDown()
    {
        // �N���b�N���ꂽ�� GameController �ɒʒm
        if (transform.parent != null)
        {
            BlockGameController gameController = transform.parent.GetComponent<BlockGameController>();
            if (gameController != null)
            {
                gameController.BlockClicked();
                Destroy(gameObject); // �u���b�N���N���b�N�ō폜
            }
        }
    }
}
