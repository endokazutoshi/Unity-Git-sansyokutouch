using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        // ボタンが押された時にStageSelectSceneに遷移
        SceneManager.LoadScene("StageSelectScene");
    }
}
