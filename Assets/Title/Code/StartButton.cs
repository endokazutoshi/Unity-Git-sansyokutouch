using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        // �{�^���������ꂽ����StageSelectScene�ɑJ��
        SceneManager.LoadScene("StageSelectScene");
    }
}
