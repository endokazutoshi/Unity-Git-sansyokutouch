using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoSelectStage : MonoBehaviour
{
    static string sLoadStage;//static�ɂ��Č^���Œ肳����悤�ɂ��Ȃ���Βl���Œ肳�ꂸ���������Ă��Ȃ����ƂɂȂ�̂�static

    public GameObject exit2;

    public void SetLoadLevel(string _loadStage)
    {
        sLoadStage = _loadStage;
        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene" )
        {
            UnityEngine.Debug.Log("�l(����)�������Ă܂���...�ꉞ");
        }
        else
        {
            UnityEngine.Debug.Log("�l(����)�������Ă܂��񂯂�...�ꉞ");
        }
    }

    public void OnClickGoStageButton()//int�^�Ő����ɂ���switch���ɂ��Ă��̂�����...
    {
        SetLoadLevel(sLoadStage);//�l(����)�������Ă邩�̃G���[����

        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene")
        {
            SceneManager.LoadScene(sLoadStage);
        }
        else
        {
            UnityEngine.Debug.Log("���̃X�e�[�W�ɂ͍s���܂���");
        }

    }

}
