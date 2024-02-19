// CubeDropper.cs
using UnityEngine;

public class CubeDropper : MonoBehaviour
{
    public float fallSpeed = 2f; // Cube�̍ŏ��̗������x
    public float maxFallSpeed = 5f; // Cube�̍ő嗎�����x

    private float currentFallSpeed;
    private bool canIncreaseSpeed = false;

    void Start()
    {
        currentFallSpeed = fallSpeed;
        Invoke("EnableSpeedIncrease", 5f); // 5�b��ɑ��x�̑���������
    }

    void EnableSpeedIncrease()
    {
        canIncreaseSpeed = true;
    }

    void Update()
    {
        // Cube�����Ɉړ�
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        // �������x�����X�ɑ���������i�ő呬�x�ɐ����j
        if (canIncreaseSpeed)
        {
            currentFallSpeed = Mathf.Min(currentFallSpeed + Time.deltaTime, maxFallSpeed);
        }
    }
}
