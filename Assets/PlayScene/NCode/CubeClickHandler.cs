//CubeClickHandler.cs
//�u���b�N���N���b�N���ꂽ�������悤�ɂ��邽�߂̃X�N���v�g
//�ŏ���5�b�̓N���b�N�ł��Ȃ��悤�ɕύX����(��ԍŏ��̃u���b�N�����ꂽ�牟����悤�ɕύX)

using UnityEngine;
using UnityEngine.UI;

public class CubeClickHandler : MonoBehaviour
{
    private Button cubeButton;

    // �֘A����Cube
    public GameObject relatedCube;

    // �N���b�N���L�����ǂ������Ǘ�����ϐ�
    private bool clickEnabled = false;

    void Start()
    {
        cubeButton = GetComponent<Button>();

        // �ŏ��̓N���b�N�𖳌��ɂ���
        cubeButton.interactable = false;

        // 5�b��ɃN���b�N��L���ɂ���
        Invoke("EnableClick", 5f);
    }

    void EnableClick()
    {
        // �N���b�N��L���ɂ���
        cubeButton.interactable = true;
    }

    void Update()
    {
        if (clickEnabled)
        {
            // �N���b�N���ꂽ�Ƃ��̏����������ɒǉ�
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    }
    // �N���b�N���ꂽ�Ƃ��̏��������J
    public void OnClick()
    {
        // GameManager�X�N���v�g��T��
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // GameManager��OnClick���\�b�h���Ăяo��
            gameManager.OnClick();
        }

        // Cube�����S�ɔj������i�I�u�W�F�N�g���폜����j
        Destroy(gameObject);

        // �֘A����Cube���j������
        if (relatedCube != null)
        {
            Destroy(relatedCube);
        }

        UnityEngine.Debug.Log("Cube Clicked!");
    }

}
