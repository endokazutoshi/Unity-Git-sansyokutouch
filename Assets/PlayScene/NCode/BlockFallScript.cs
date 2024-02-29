using System.Collections;
using UnityEngine;

public class BlockFallScript : MonoBehaviour
{
    private float initialFallSpeed = 2.0f;  // 初期の落下速度
    private bool isFalling = true;

    private void Start()
    {
        StartCoroutine(FallCoroutine());
    }

    IEnumerator FallCoroutine()
    {
        yield return new WaitForSeconds(5.0f); // 5秒待機

        while (isFalling)
        {
            // ブロックを下に移動させる
            transform.Translate(Vector3.down * GetFallSpeed() * Time.deltaTime);

            // 0.1秒待機
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void StopFalling()
    {
        isFalling = false;
    }

    private float GetFallSpeed()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            int score = gameManager.GetScore();
            Debug.Log("Current Score: " + score);

            // スコアに基づいて速度を返す
            return initialFallSpeed + score;
        }
        else
        {
            return initialFallSpeed;
        }
    }
}
