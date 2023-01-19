using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] public List<LevelData> _spawned_levels;
    private GameObject _tempLevelHolder;
    public float ChangeLevel(int currentLevel, bool hasWon)
    {
       StartCoroutine(RecreateLevel(currentLevel));
        if (hasWon)
        {
            _spawned_levels[currentLevel + 1].gameObject.SetActive(true);
            return _levels[currentLevel + 1].ProgressBarIncreaseRate;
        }
            return _levels[currentLevel].ProgressBarIncreaseRate;
    }


    IEnumerator RecreateLevel(int currentLevel)
    {
        yield return new WaitForEndOfFrame();
        _tempLevelHolder = _spawned_levels[currentLevel].gameObject;
        Destroy(_tempLevelHolder);
        _tempLevelHolder = Instantiate(_levels[currentLevel].gameObject);
        _spawned_levels.RemoveAt(currentLevel);
        _spawned_levels.Insert(currentLevel, _tempLevelHolder.GetComponent<LevelData>());
        _spawned_levels[currentLevel].gameObject.SetActive(false);
    }
    public LevelData GetCurrentLevel(int level)
    {
        return _spawned_levels[level];
    }
    public void CreateLevels()
    {
       foreach(var ref_obj in _levels)
        {
            var spawned_obj = Instantiate(ref_obj.gameObject);
            spawned_obj.GetComponent<LevelData>().Init();
            spawned_obj.SetActive(false);
            _spawned_levels.Add(spawned_obj.GetComponent<LevelData>());

        }
        _spawned_levels[0].gameObject.SetActive(true);
    }

    public void ClearLevels()
    {
        _spawned_levels.Clear();
    }


}

