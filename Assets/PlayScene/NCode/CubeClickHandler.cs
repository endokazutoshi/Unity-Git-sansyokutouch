using UnityEngine;
using UnityEngine.UI;

public class CubeClickHandler : MonoBehaviour
{
    private Button cubeButton;

    // 関連するCube
    public GameObject relatedCube;

    // クリックが有効かどうかを管理する変数
    private bool clickEnabled = false;

    void Start()
    {
        cubeButton = GetComponent<Button>();

        // 最初はクリックを無効にする
        cubeButton.interactable = false;

        // 5秒後にクリックを有効にする
        Invoke("EnableClick", 5f);
    }

    void EnableClick()
    {
        // クリックを有効にする
        cubeButton.interactable = true;
    }

    void Update()
    {
        if (clickEnabled)
        {
            // クリックされたときの処理をここに追加
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    }
    // クリックされたときの処理を公開
    public void OnClick()
    {
        // GameManagerスクリプトを探す
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // GameManagerのOnClickメソッドを呼び出す
            gameManager.OnClick();
        }

        // Cubeを完全に破棄する（オブジェクトを削除する）
        Destroy(gameObject);

        // 関連するCubeも破棄する
        if (relatedCube != null)
        {
            Destroy(relatedCube);
        }

        UnityEngine.Debug.Log("Cube Clicked!");
    }

}
