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
    public float minX = -300.0f; // ���̐���
    public float maxX = 200.0f; // �E�̐���

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
        // �����_���ȉ��ʒu���v�Z�i���E�͈̔͂𐧌��j
        float randomX = Random.Range(minX, maxX);

        // Cube�̐���
        GameObject newCube = Instantiate(cubePrefab, canvasRect);

        // RectTransform�̈ʒu��ݒ�
        RectTransform cubeRect = newCube.GetComponent<RectTransform>();
        cubeRect.anchoredPosition = new Vector2(randomX, cubeHeight);

        // ���̏�����ǉ�...

        // Cube�ɗ����X�N���v�g���A�^�b�`
        CubeDropper dropper = newCube.AddComponent<CubeDropper>();
        dropper.FallSpeed = currentCubeFallSpeed; // �������x��ݒ�
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
    // �X�R�A���擾���郁�\�b�h��ǉ�
    public int GetScore()
    {
        return score;
    }
}
