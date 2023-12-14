using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSelect : MonoBehaviour
{
    public string sLoadStage;//stringloadstage※ステージの名前を入力
    // Start is called before the first frame update

    private GoSelectStage goSelectStage;

    private void Awake()//クラスのやつ
    {
        goSelectStage = gameObject.AddComponent<GoSelectStage>();
    }
   
    public void OnClickButton()
    {
        if(sLoadStage == "RankBattleScene" || sLoadStage == "ScoreAttackScene" )
        {
            UnityEngine.Debug.Log("値(文字)を入れました");//値が入ってる
            goSelectStage.SetLoadLevel(sLoadStage);//goSelectStageのSetLoadLevelに文字を送った...
        }
        else
        {
            UnityEngine.Debug.Log("値(文字)が入っていません");//値が入ってない
        }
    }
}
