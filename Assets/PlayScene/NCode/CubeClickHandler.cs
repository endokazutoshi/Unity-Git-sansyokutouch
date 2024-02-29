// CubeClickHandler.cs
using UnityEngine;
using UnityEngine.UI;

public class CubeClickHandler : MonoBehaviour
{
    private Button cubeButton;
    private CubeDropper dropper; // CubeDropper クラスへの参照を保持する変数を追加

    public GameObject relatedCube;

    private bool clickEnabled = false;

    void Start()
    {
        cubeButton = GetComponent<Button>();
        cubeButton.interactable = false;

        dropper = GetComponent<CubeDropper>(); // CubeDropper コンポーネントを取得

        Invoke("EnableClick", 0f);
    }

    void EnableClick()
    {
        cubeButton.interactable = true;
    }

    void Update()
    {
        if (clickEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    }

    public void OnClick()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            PerformOperation(gameManager); // 新しく追加したメソッドを呼び出す
            gameManager.OnClick();
        }

        Destroy(gameObject);
        if (relatedCube != null)
        {
            Destroy(relatedCube);
        }

        UnityEngine.Debug.Log("Cube Clicked!");
    }

    // GameManager から得たスコアに基づいて操作を行うメソッド
    public void PerformOperation(GameManager gameManager)
    {
        if (dropper != null)
        {
            switch (dropper.OperationType)
            {
                case OperationType.Addition:
                    gameManager.AddScore(10);
                    break;
                case OperationType.Subtraction:
                    gameManager.SubtractScore(10);
                    break;
                case OperationType.Multiplication:
                    gameManager.MultiplyScore(2);
                    break;
                case OperationType.Division:
                    gameManager.DivideScore(2);
                    break;
                default:
                    break;
            }
        }
    }
}
