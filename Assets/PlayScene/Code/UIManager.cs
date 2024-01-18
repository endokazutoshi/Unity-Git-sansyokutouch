using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // Prefab���i�[���邽�߂̕ϐ�
    public float spawnInterval = 2f; // UI�𐶐�����Ԋu

    void Start()
    {
        // ���Ԋu��UI�𐶐�����
        InvokeRepeating("SpawnFallingObject", 0f, spawnInterval);
    }

    void SpawnFallingObject()
    {
        // Prefab����UI�𐶐����A�����_���Ȉʒu�ɔz�u
        GameObject fallingObject = Instantiate(fallingObjectPrefab, new Vector3(0, 10f, 0), Quaternion.identity);

        // �}�E�X�ŃN���b�N�����Ƃ��ɃI�u�W�F�N�g��j���ł���悤�ɂ���
        fallingObject.AddComponent<BoxCollider2D>();
    }
}
