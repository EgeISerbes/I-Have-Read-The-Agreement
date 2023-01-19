using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _pauseMenu;
    public System.Action<bool> OnExit;
    public GameObject _startMenu;
    public GameObject endMenu;
    public GameObject mainText;
    public GameObject settingsText;
    public GameObject mainButtons;
    public GameObject returnButtons;
   [SerializeField] private Virus _virus;
    [SerializeField] private IntroScript _introScript;

    private void Awake()
    {
        _startMenu.SetActive(true);
        _virus.gameObject.SetActive(false);
    }
    public void Init(System.Action<bool> OnExit)
    {
        this.OnExit = OnExit;
        _pauseMenu.gameObject.SetActive(false);
    }
    public void GameStarted()
    {
        _startMenu.gameObject.SetActive(false);
        _introScript.gameObject.SetActive(true);
        _introScript.AwakeIntro();
    }
    public void GameEnded()
    {
        endMenu.SetActive(true);
    }

    public void SettingsPressed()
    {
        mainButtons.SetActive(false);
        mainText.SetActive(false);
        settingsText.SetActive(true);
        returnButtons.SetActive(true);
    }
    public void ReturnPressed()
    {
        mainButtons.SetActive(true);
        mainText.SetActive(true);
        settingsText.SetActive(false);
        returnButtons.SetActive(false);
    }
    public void GamePaused()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _pauseMenu.gameObject.SetActive(true);
    }
    public void GameResumed()
    {
        Debug.Log("dasdsa");
        Time.timeScale = 1f;
        _pauseMenu.gameObject.SetActive(false);
    }
    public void GameRestarted()
    {
        OnExit(false);
    }
    public void GameExited()
    {
        Application.Quit();
    }
}
