using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoSelectStage : MonoBehaviour
{
    static string sLoadStage;//staticにして型を固定させるようにしなければ値が固定されず何も入っていないことになるのでstatic

    public GameObject exit2;

    public void SetLoadLevel(string _loadStage)
    {
        sLoadStage = _loadStage;
        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene" )
        {
            UnityEngine.Debug.Log("値(文字)が入ってますよ...一応");
        }
        else
        {
            UnityEngine.Debug.Log("値(文字)が入ってませんけど...一応");
        }
    }

    public void OnClickGoStageButton()//int型で数字にしてswitch文にしてやるのもあり...
    {
        SetLoadLevel(sLoadStage);//値(文字)が入ってるかのエラー処理

        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene")
        {
            SceneManager.LoadScene(sLoadStage);
        }
        else
        {
            UnityEngine.Debug.Log("そのステージには行けません");
        }

    }

}
