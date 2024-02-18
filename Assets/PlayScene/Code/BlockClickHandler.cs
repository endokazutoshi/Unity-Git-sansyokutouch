// BlockClickHandler.cs

using UnityEngine;
using UnityEngine.EventSystems;  // UnityEngine.EventSystems��ǉ�

public class BlockClickHandler : MonoBehaviour, IPointerDownHandler
{
    private bool canClick = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canClick)
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
}
