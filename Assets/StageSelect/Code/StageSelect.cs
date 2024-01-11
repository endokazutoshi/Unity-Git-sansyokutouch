using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageSelect : MonoBehaviour
{
    public int StageNumber;


    // Update is called once per frame
    public void OnClickStageLoad()
    {
        switch(StageNumber)
        {
            case 1:
                SceneManager.LoadScene("ScoreAttackScene");
                break;
            case 2:
                SceneManager.LoadScene("RankBattleScene");
                break;
        }
        UnityEngine.Debug.Log("‘I‘ğ‚µ‚½ƒV[ƒ“‚ÉˆÚ“®‚µ‚Ü‚·");
    }
}