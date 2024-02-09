// BlockClickHandler.cs

using UnityEngine;

public class BlockClickHandler : MonoBehaviour
{
    // ブロックがクリックされた時の処理
    private void OnMouseDown()
    {
        // クリックされたら GameController に通知
        if (transform.parent != null)
        {
            BlockGameController gameController = transform.parent.GetComponent<BlockGameController>();
            if (gameController != null)
            {
                gameController.BlockClicked();
                Destroy(gameObject); // ブロックをクリックで削除
            }
        }
    }
}
