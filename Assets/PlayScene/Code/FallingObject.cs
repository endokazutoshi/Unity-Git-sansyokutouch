using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float firstSpeed = 0f; // �����x
    public float nextSpeed = 5f; // �����x
    public float maxCubeSpeed = 10f; // �������̍ō����x
    static float fixedYPosition = 450f;

    private float currentSpeed; // ���݂̑��x 
    
    static float minYPosition = -70f; // ��ʊO��Y���W��-70���炢�ɒB�����������悤�ɐݒ�
    
    void Start()
    {
        currentSpeed = firstSpeed;

        // �����ʒu�������_���ɐݒ�
        float randomX = Random.Range(150f, 700f); // X���W�͈̔͂𒲐� //(150f, 700f)
        transform.position = new Vector3(randomX, fixedYPosition, 0);
    }

    void Update()
    {
        // �t���[�����Ƃ�UI�𗎉�������
        Fall();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void Fall()
    {
        // ����������
        currentSpeed += nextSpeed * Time.deltaTime;

        // �ō����x�𐧌�����
        currentSpeed = Mathf.Min(currentSpeed, maxCubeSpeed);

        // ���������鑬�x�ƕ�����ݒ�
        Vector3 fallVector = new Vector3(0, -currentSpeed * Time.deltaTime, 0);

        // UI���ړ�������
        transform.Translate(fallVector);

        // ��ʊO�ɏo����I�u�W�F�N�g��j��
        if (transform.position.y < minYPosition)
        {
            Destroy(gameObject);
        }
    }
}
