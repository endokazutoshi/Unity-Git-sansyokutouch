using System.Collections;
using UnityEngine;

public class BlockFallScript : MonoBehaviour
{
    private float initialFallSpeed = 2.0f;  // �����̗������x
    private bool isFalling = true;

    private void Start()
    {
        StartCoroutine(FallCoroutine());
    }

    IEnumerator FallCoroutine()
    {
        yield return new WaitForSeconds(5.0f); // 5�b�ҋ@

        while (isFalling)
        {
            // �u���b�N�����Ɉړ�������
            transform.Translate(Vector3.down * GetFallSpeed() * Time.deltaTime);

            // 0.1�b�ҋ@
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

            // �X�R�A�Ɋ�Â��đ��x��Ԃ�
            return initialFallSpeed + score;
        }
        else
        {
            return initialFallSpeed;
        }
    }
}
