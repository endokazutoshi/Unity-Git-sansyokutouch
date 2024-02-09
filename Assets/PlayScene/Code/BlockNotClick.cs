// BlockNotClick.cs

using UnityEngine;

public class BlockNotClick : MonoBehaviour
{
    private bool canClick = false;

    void Start()
    {
        // 5秒後にクリックを受け付けるようにする
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
