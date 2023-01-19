using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private float progress_bar_increase_rate;
    [SerializeField] private int max_defenders_count;
    private List<Collectable> _collectableList = new List<Collectable>();
    private int _current_defender_count;
   [SerializeField] private FolderIcon _folderIcon;
    [SerializeField] private GameObject _levelPiece;
    public Transform _startPos;
    public GameObject LevelPiece
    {
        get => (_levelPiece!=null)?_levelPiece:null;
    }
    public List<Collectable> CollectableList
    {
        get => _collectableList;
    }
    public int TotalDefenderCount
    {
        get => max_defenders_count;
    }
    public float ProgressBarIncreaseRate
    {
        get => progress_bar_increase_rate;
    }
    public void Init()
    {   if(_levelPiece!=null)
        {
            foreach (var col in _levelPiece.GetComponentsInChildren<Collectable>())
            {
                _collectableList.Add(col);
            }
        }
        
        _current_defender_count = gameObject.GetComponentsInChildren<AntiVirus>().Length;
    }
    public void ActivateFolderIfAvailable()
    {
        if(_folderIcon !=null)
        {
            _folderIcon.ActivateFolder();
        }
    }

}
