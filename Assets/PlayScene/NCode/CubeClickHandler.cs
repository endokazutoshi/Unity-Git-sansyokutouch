// CubeClickHandler.cs
using UnityEngine;
using UnityEngine.UI;

public class CubeClickHandler : MonoBehaviour
{
    private Button cubeButton;
    private CubeDropper dropper; // CubeDropper �N���X�ւ̎Q�Ƃ�ێ�����ϐ���ǉ�

    public GameObject relatedCube;

    private bool clickEnabled = false;

    void Start()
    {
        cubeButton = GetComponent<Button>();
        cubeButton.interactable = false;

        dropper = GetComponent<CubeDropper>(); // CubeDropper �R���|�[�l���g���擾

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
            PerformOperation(gameManager); // �V�����ǉ��������\�b�h���Ăяo��
            gameManager.OnClick();
        }

        Destroy(gameObject);
        if (relatedCube != null)
        {
            Destroy(relatedCube);
        }

        UnityEngine.Debug.Log("Cube Clicked!");
    }

    // GameManager ���瓾���X�R�A�Ɋ�Â��đ�����s�����\�b�h
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
