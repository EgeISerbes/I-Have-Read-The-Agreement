using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AIManager _aiManager;
    [SerializeField] private CollectableManager _collectableManager;

    [SerializeField] private Mouse _mouse;
    [SerializeField] private Virus _virusChar;

    public int _currentLevel = 0;
    private float _progressBar = 0;
    private float _progressLevelIncreaseRate = 0f;
    private bool _canChange = true;
    private LevelData _currentLevelData;

    public void AwakeManager()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _levelManager.CreateLevels();
        Init();
    }
    private void Init()
    {
        _currentLevelData = _levelManager.GetCurrentLevel(_currentLevel);
        _virusChar.Init(this);
        _aiManager.Init(_currentLevelData);
        _collectableManager.Init(_currentLevelData);
        _mouse.Init(_aiManager, _currentLevelData);
        _uiManager.Init(OnLevelChange);
    }
    public void GamePaused()
    {
        _uiManager.GamePaused();
    }

    public void OnLevelChange(bool isFinished)
    {
        if (_canChange)
        {
            _canChange = false;

            if (isFinished)
            {   
                if(_currentLevel == _levelManager._spawned_levels.Count-1)
                {
                    _uiManager.GameEnded();
                }
                _progressLevelIncreaseRate = _levelManager.ChangeLevel(_currentLevel, true);
                _currentLevel += 1;
                StartCoroutine(WaitForBoolChange());
            }
            else
            {
                _progressLevelIncreaseRate = _levelManager.ChangeLevel(_currentLevel, false);

            }

            Init();

        }

    }
    IEnumerator WaitForBoolChange()
    {
        yield return new WaitForSeconds(1);
        _canChange = true;
    }

}
