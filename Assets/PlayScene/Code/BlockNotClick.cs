// BlockNotClick.cs

using UnityEngine;

public class BlockNotClick : MonoBehaviour
{
    private bool canClick = false;

    void Start()
    {
        // 5�b��ɃN���b�N���󂯕t����悤�ɂ���
        Invoke("EnableClick", 5f);
    }

    public bool CanClick()
    {
        return canClick;
    }

    void EnableClick()
    {
        canClick = true;
    }
}
