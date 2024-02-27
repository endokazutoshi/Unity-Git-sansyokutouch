// FirstCubeDropper.cs
using UnityEngine;

public class FirstCubeDropper : MonoBehaviour
{
    public float fallSpeed = 5f; // Cubeの落下速度
    public float maxFallSpeed = 10f; // Cubeの最大落下速度
    private bool isScriptEnabled = true; // スクリプトの有効/無効を管理するフラグ

    void Update()
    {
        // isScriptEnabledがtrueの場合にのみ実行
        if (isScriptEnabled)
        {
            // Cubeを下に移動
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // 落下速度を徐々に増加させる（最大速度に制限）
            fallSpeed = Mathf.Min(fallSpeed + Time.deltaTime, maxFallSpeed);
        }
    }

    // クローンされたオブジェクトに対してスクリプトを無効にするメソッド
    public void DisableScript()
    {
        isScriptEnabled = false;
    }
}
