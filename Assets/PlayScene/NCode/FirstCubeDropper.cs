// FirstCubeDropper.cs
using UnityEngine;

public class FirstCubeDropper : MonoBehaviour
{
    public float fallSpeed = 5f; // Cube�̗������x
    public float maxFallSpeed = 10f; // Cube�̍ő嗎�����x
    private bool isScriptEnabled = true; // �X�N���v�g�̗L��/�������Ǘ�����t���O

    void Update()
    {
        // isScriptEnabled��true�̏ꍇ�ɂ̂ݎ��s
        if (isScriptEnabled)
        {
            // Cube�����Ɉړ�
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // �������x�����X�ɑ���������i�ő呬�x�ɐ����j
            fallSpeed = Mathf.Min(fallSpeed + Time.deltaTime, maxFallSpeed);
        }
    }

    // �N���[�����ꂽ�I�u�W�F�N�g�ɑ΂��ăX�N���v�g�𖳌��ɂ��郁�\�b�h
    public void DisableScript()
    {
        isScriptEnabled = false;
    }
}
