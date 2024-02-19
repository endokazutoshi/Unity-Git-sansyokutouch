// CubeDropper.cs
using UnityEngine;

public class CubeDropper : MonoBehaviour
{
    public float fallSpeed = 2f; // Cubeの最初の落下速度
    public float maxFallSpeed = 5f; // Cubeの最大落下速度

    private float currentFallSpeed;
    private bool canIncreaseSpeed = false;

    void Start()
    {
        currentFallSpeed = fallSpeed;
        Invoke("EnableSpeedIncrease", 5f); // 5秒後に速度の増加を許可
    }

    void EnableSpeedIncrease()
    {
        canIncreaseSpeed = true;
    }

    void Update()
    {
        // Cubeを下に移動
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        // 落下速度を徐々に増加させる（最大速度に制限）
        if (canIncreaseSpeed)
        {
            currentFallSpeed = Mathf.Min(currentFallSpeed + Time.deltaTime, maxFallSpeed);
        }
    }
}
