using UnityEngine;

public class GameController : MonoBehaviour
{
    public FallingObject fallingObjectPrefab;

    void Start()
    {
        InvokeRepeating("SpawnFallingObject", 0f, 1f);
        Invoke("StopSpawning", 60f); // 60�b��Ƀu���b�N�������~
    }

    void SpawnFallingObject()
    {
        // Instantiate�Ő������ꂽ�I�u�W�F�N�g�̎Q�Ƃ�ێ�
        FallingObject fallingObject = Instantiate(fallingObjectPrefab);

        // null�`�F�b�N���s���Ă��珈�������s
        if (fallingObject != null)
        {
            // �����ɏ�����ǉ�
        }
    }

    void StopSpawning()
    {
        CancelInvoke("SpawnFallingObject");
    }
}
