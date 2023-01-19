using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private LevelData _currentLevel;
    private int total_col_count = 0;
    public void Init(LevelData levelData)
    {
        _currentLevel = levelData;
        var tempArr = _currentLevel.CollectableList;
        if(tempArr != null)
        {
            total_col_count = tempArr.Count;
            foreach(var col in tempArr)
            {
                col.Init(RemoveCollectable);
            }
        }
    }

    
   public void RemoveCollectable()
    {
        total_col_count -= 1;
        if (total_col_count<=0)
        {
            _currentLevel.ActivateFolderIfAvailable();
        }
    }
}
