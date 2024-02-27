// CubeSpawner.cs
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Cube��Prefab��Inspector����֘A�t��
    public RectTransform canvasRect; // Canvas��RectTransform��Inspector����֘A�t��
    public float minSpawnInterval = 1.0f; // Cube�̐����ŏ��Ԋu
    public float maxSpawnInterval = 3.0f; // Cube�̐����ő�Ԋu
    public float cubeHeight = 0f; // Cube�̍���
    public float initialCubeFallSpeed = 5f; // ������Cube�̗������x
    public float maxCubeFallSpeed = 15f; // �ő��Cube�̗������x

    private float timer = 0f;
    private float spawnInterval = 0f;
    private float currentCubeFallSpeed;

    private int score = 0;

    void Start()
    {
        CalculateNewSpawnInterval();
        currentCubeFallSpeed = initialCubeFallSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
            CalculateNewSpawnInterval();
        }

        // �X�R�A���オ��ɂ�ė����X�s�[�h���グ��
        currentCubeFallSpeed = Mathf.Min(initialCubeFallSpeed + (score * 0.1f), maxCubeFallSpeed);
    }

    void CalculateNewSpawnInterval()
    {
        // �����_���ȊԊu���v�Z
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnCube()
    {
        // Canvas�͈̔͂��l�����ă����_���Ȉʒu���v�Z
        Vector2 randomPosition = GetRandomPosition();

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
        dropper.fallSpeed = currentCubeFallSpeed; // �������x��ݒ�
    }

    Vector2 GetRandomPosition()
    {
        // �����_���Ȉʒu���v�Z
        Vector2 randomPosition = new Vector2(Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f),
                                             Random.Range(-canvasRect.rect.height / 2f, canvasRect.rect.height / 2f));

        // �������ꂽCube������Cube�Əd�Ȃ��Ă��Ȃ����`�F�b�N
        Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, 1f); // 1f�͓K�؂Ȕ����a
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Cube"))
            {
                // ����Cube�Əd�Ȃ��Ă���ꍇ�A�ċA�I�Ɉʒu���v�Z
                return GetRandomPosition();
            }
        }

        return randomPosition;
    }

    // �X�R�A���オ�����Ƃ��ɌĂ΂�郁�\�b�h
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
