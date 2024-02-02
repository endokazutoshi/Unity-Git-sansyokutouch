using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour
{
    public float firstSpeed = 10.0f; // �����x
    public float nextSpeed = 5f; // �����x
    public float maxCubeSpeed = 10f; // �������̍ō����x
    public float spawnInterval = 1.0f; // �u���b�N�̐����Ԋu
    public float totalTimeLimit = 30.0f; // �������ԁi�b�j

    private float currentSpeed; // ���݂̑��x
    private Color blockColor; // �u���b�N�̐F
    private float elapsedTime; // �o�ߎ���

    static float minYPosition = -70f; // ��ʊO��Y���W �� -70���炢�ɒB�����������悤�ɐݒ�

    // �ǉ�: �^�[�Q�b�g�̃u���b�N�̐F
    public Color targetColor;

    // �ǉ�: �X�R�A�̑����l
    public int scoreValue = 10;

    // �ǉ�: �X�R�A��\������e�L�X�g
    public Text scoreText;

    void Start()
    {
        currentSpeed = firstSpeed;
        elapsedTime = 0f;

        // �u���b�N�̐������J�n
        InvokeRepeating("SpawnBlock", 0f, spawnInterval);
        // Collider�𖳌��ɂ���
        GetComponent<Collider2D>().enabled = false;

        // �ǉ�: �X�R�A�e�L�X�g�̏�����
        UpdateScore();
    }

    void UpdateScore()
    {
        // �ǉ�: �X�R�A�e�L�X�g���X�V
        scoreText.text = "Score: " + ScoreManager.score;
    }

    void SpawnBlock()
    {
        if (elapsedTime < totalTimeLimit)
        {
            // �����ʒu�ƐF�������_���ɐݒ�i���̓����F�̃u���b�N�Əd�Ȃ�Ȃ��悤�ɒ����j
            SetRandomPositionAndColor();
        }
        else
        {
            // �������Ԃ��o�߂����琶�����~
            CancelInvoke("SpawnBlock");
        }
    }

    void SetRandomPositionAndColor()
    {
        float randomX, randomY;

        // �d�Ȃ������邽�߂Ƀ��[�v
        do
        {
            randomX = Random.Range(150f, 700f);
            randomY = Random.Range(450f, 500f);
        } while (CheckOverlap(randomX, randomY));

        transform.position = new Vector3(randomX, randomY, 0);
        blockColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<SpriteRenderer>().color = blockColor;

        // Collider��L���ɂ���
        GetComponent<Collider2D>().enabled = true;
    }

    bool CheckOverlap(float x, float y)
    {
        // Collider���d�Ȃ��Ă��邩���m�F
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(x, y), 1f);

        // �����F�̃u���b�N������ꍇ��true�A�Ȃ��ꍇ��false��Ԃ�
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.GetComponent<FallingObject>()?.blockColor == blockColor)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        // �t���[�����Ƃ�UI�𗎉�������
        Fall();

        // ��ʊO�ɏo����I�u�W�F�N�g��j��
        if (transform.position.y < minYPosition)
        {
            Debug.Log("Spawn new block at " + Time.time); // �f�o�b�O���O��ǉ�
            // �X�|�[��������
            SetRandomPositionAndColor();
        }
    }

    public void OnMouseDown()
    {
        // �u���b�N���N���b�N���ꂽ�Ƃ��̏���
        if (blockColor == targetColor)
        {
            IncrementScore();
        }

        // �u���b�N���폜
        Destroy(gameObject);
    }

    void IncrementScore()
    {
        ScoreManager.score += scoreValue;
        FindObjectOfType<ScoreManager>().UpdateScore();
        UpdateScore(); // �ǉ�: �X�R�A���X�V
    }

    void Fall()
    {
        // ���x��������
        if (elapsedTime < totalTimeLimit)
        {
            currentSpeed = firstSpeed;
        }

        // ����������
        currentSpeed += nextSpeed * Time.deltaTime;

        // �ō����x�𐧌�����
        currentSpeed = Mathf.Min(currentSpeed, maxCubeSpeed);

        // ���������鑬�x�ƕ�����ݒ�
        Vector3 fallVector = new Vector3(0, -currentSpeed * Time.deltaTime, 0);

        // UI���ړ�������
        transform.Translate(fallVector);
    }

}
