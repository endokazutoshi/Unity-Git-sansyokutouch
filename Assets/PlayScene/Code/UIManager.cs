using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // �u���b�N��Prefab
    public RectTransform canvasRect; // Canvas��RectTransform
    public float spawnInterval = 2f; // �u���b�N�𐶐�����Ԋu
    private float timer = 0f;

    void Update()
    {
        // �^�C�}�[���X�V
        timer += Time.deltaTime;

        // ��莞�Ԃ��ƂɃu���b�N�𐶐�
        if (timer >= spawnInterval)
        {
            SpawnFallingObject();
            timer = 0f; // �^�C�}�[�����Z�b�g
        }
    }

    void SpawnFallingObject()
    {
        // �u���b�N�𐶐�����ʒu��Canvas���̃����_���Ȉʒu�ɕύX
        float spawnX = Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f);
        float spawnY = canvasRect.rect.height / 2f;

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Prefab����u���b�N�𐶐����ACanvas�̎q�I�u�W�F�N�g�ɐݒ�
        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        fallingObject.transform.SetParent(canvasRect, false); // Canvas���ł̑��ΓI�ȍ��W���ێ�

        // �}�E�X�ŃN���b�N�����Ƃ��ɃI�u�W�F�N�g��j���ł���悤�ɂ���
        fallingObject.AddComponent<BoxCollider2D>();
    }
}
