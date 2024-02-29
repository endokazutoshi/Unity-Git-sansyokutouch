using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½Žž‚ÉStageSelectScene‚É‘JˆÚ
        SceneManager.LoadScene("StageSelectScene");
    }
}
