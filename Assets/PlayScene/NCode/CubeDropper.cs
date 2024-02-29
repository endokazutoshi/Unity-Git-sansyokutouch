// CubeDropper.cs
using UnityEngine;

public class CubeDropper : MonoBehaviour
{
    private float initialFallSpeed = 30f;  // �����X�s�[�h��30�ɕύX
    private float maxBaseFallSpeed = 10f;  // ��{�̍ő嗎�����x
    private float currentFallSpeed;
    private bool canIncreaseSpeed = false;

    void Start()
    {
        currentFallSpeed = initialFallSpeed;
        Invoke("EnableSpeedIncrease", 5f);
    }

    void EnableSpeedIncrease()
    {
        canIncreaseSpeed = true;
    }

    public float FallSpeed
    {
        get { return currentFallSpeed; }
        set { currentFallSpeed = value; }
    }

    void Update()
    {
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        if (canIncreaseSpeed)
        {
            // ��{�̍ő嗎�����x�ɃX�R�A�̒l�����Z
            currentFallSpeed = Mathf.Min(currentFallSpeed + Time.deltaTime, maxBaseFallSpeed + GetScoreMultiplier());
        }
    }

    float GetScoreMultiplier()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            int score = gameManager.GetScore();
            Debug.Log("Current Score: " + score);

            // �X�R�A�Ɋ�Â��đ��x��Ԃ�
            return score;
        }
        else
        {
            return 0;
        }
    }
}
