// BlockClickHandler.cs

using UnityEngine;
using UnityEngine.EventSystems;  // UnityEngine.EventSystemsを追加

public class BlockClickHandler : MonoBehaviour, IPointerDownHandler
{
    private bool canClick = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canClick)
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
}
