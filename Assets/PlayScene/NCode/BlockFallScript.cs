using System.Collections;
using UnityEngine;

public class BlockFallScript : MonoBehaviour
{
    public float fallSpeed = 2.0f;
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
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // 0.1秒待機
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void StopFalling()
    {
        isFalling = false;
    }
}

