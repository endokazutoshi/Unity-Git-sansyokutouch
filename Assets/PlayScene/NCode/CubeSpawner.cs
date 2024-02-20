// CubeSpawner.cs
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Cube��Prefab��Inspector����֘A�t��
    public RectTransform canvasRect; // Canvas��RectTransform��Inspector����֘A�t��
    public float spawnInterval = 1.5f; // Cube�̐����Ԋu
    public float cubeHeight = 0f; // Cube�̍���
    public float cubeFallSpeed = 5f; // Cube�̗������x

    private float timer = 0f;
    private bool canSpawn = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            canSpawn = true;
        }

        // ��莞�Ԃ��Ƃ�Cube�𐶐�
        if (canSpawn && timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        // Canvas�͈̔͂��l�����ă����_���Ȉʒu���v�Z
        Vector2 randomPosition = new Vector2(Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f),
                                             Random.Range(-canvasRect.rect.height / 2f, canvasRect.rect.height / 2f));

        // Cube�̐���
        GameObject newCube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);

        // ���̏�����ǉ�...

        // �������ꂽCube��Canvas���Ɏ��܂�悤�ɂ���
        RectTransform cubeRect = newCube.GetComponent<RectTransform>();
        cubeRect.SetParent(canvasRect);
        cubeRect.anchoredPosition = randomPosition;

        // Cube�̍�����ݒ�
        Vector3 cubePosition = newCube.transform.position;
        cubePosition.y = cubeHeight;
        newCube.transform.position = cubePosition;

        // Cube�ɗ����X�N���v�g���A�^�b�`
        CubeDropper dropper = newCube.AddComponent<CubeDropper>();
        dropper.fallSpeed = cubeFallSpeed; // �����ŗ������x��ݒ�
    }
}

