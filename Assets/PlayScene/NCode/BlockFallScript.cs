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
        yield return new WaitForSeconds(5.0f); // 5�b�ҋ@

        while (isFalling)
        {
            // �u���b�N�����Ɉړ�������
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // 0.1�b�ҋ@
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void StopFalling()
    {
        isFalling = false;
    }
}

