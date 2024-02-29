// CubeDropper.cs
using UnityEngine;

public class CubeDropper : MonoBehaviour
{
    private float initialFallSpeed = 30f;  // 初期スピードを30に変更
    private float maxBaseFallSpeed = 10f;  // 基本の最大落下速度
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
            // 基本の最大落下速度にスコアの値を加算
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

            // スコアに基づいて速度を返す
            return score;
        }
        else
        {
            return 0;
        }
    }
}
