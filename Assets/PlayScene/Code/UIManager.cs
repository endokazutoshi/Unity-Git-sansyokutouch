using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // Prefabを格納するための変数
    public float spawnInterval = 2f; // UIを生成する間隔

    void Start()
    {
        // 一定間隔でUIを生成する
        InvokeRepeating("SpawnFallingObject", 0f, spawnInterval);
    }

    void SpawnFallingObject()
    {
        // PrefabからUIを生成し、ランダムな位置に配置
        GameObject fallingObject = Instantiate(fallingObjectPrefab, new Vector3(0, 10f, 0), Quaternion.identity);

        // マウスでクリックしたときにオブジェクトを破棄できるようにする
        fallingObject.AddComponent<BoxCollider2D>();
    }
}
