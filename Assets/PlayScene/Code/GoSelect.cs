using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSelect : MonoBehaviour
{
    public string sLoadStage;//stringloadstage���X�e�[�W�̖��O�����
    // Start is called before the first frame update

    private GoSelectStage goSelectStage;

    private void Awake()//�N���X�̂��
    {
        goSelectStage = gameObject.AddComponent<GoSelectStage>();
    }
   
    public void OnClickButton()
    {
        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene" )
        {
            UnityEngine.Debug.Log("�l(����)�����܂���");//�l�������Ă�
            goSelectStage.SetLoadLevel(sLoadStage);//goSelectStage��SetLoadLevel�ɕ����𑗂���...
        }
        else
        {
            UnityEngine.Debug.Log("�l(����)�������Ă��܂���");//�l�������ĂȂ�
        }
    }
}
