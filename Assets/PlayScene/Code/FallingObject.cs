using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float firstSpeed = 0f; // 初速度
    public float nextSpeed = 5f; // 加速度
    public float maxCubeSpeed = 10f; // 落下時の最高速度
    public float minYPosition = -70f; // 画面外のY座標→-70ぐらいに達したら消えるように設定

    private float currentSpeed; // 現在の速度

    void Start()
    {
        currentSpeed = firstSpeed;

        // 初期位置をランダムに設定
        float randomX = Random.Range(0f, 30f); // X座標の範囲を調整
        transform.position = new Vector3(randomX, 10f, 0);
    }

    void Update()
    {
        // フレームごとにUIを落下させる
        Fall();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void Fall()
    {
        // 加速させる
        currentSpeed += nextSpeed * Time.deltaTime;

        // 最高速度を制限する
        currentSpeed = Mathf.Min(currentSpeed, maxCubeSpeed);

        // 落下させる速度と方向を設定
        Vector3 fallVector = new Vector3(0, -currentSpeed * Time.deltaTime, 0);

        // UIを移動させる
        transform.Translate(fallVector);

        // 画面外に出たらオブジェクトを破棄
        if (transform.position.y < minYPosition)
        {
            Destroy(gameObject);
        }
    }
}
