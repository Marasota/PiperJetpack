using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 500;
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AndroidScene");
    }
}
