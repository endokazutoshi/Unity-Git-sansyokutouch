using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // �N���b�N���̏����������ɒǉ�
        Debug.Log("UI���N���b�N����܂����I");
    }
}
