using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // クリック時の処理をここに追加
        Debug.Log("UIがクリックされました！");
    }
}
