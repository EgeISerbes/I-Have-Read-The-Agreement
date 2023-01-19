using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private int _maxDefendersCount;
    private int _spawned_defenders_count;
    private bool _canSpawn = true;
   [SerializeField] private AntiVirus _defender_Ref;
   [SerializeField] private List<AntiVirus> activeAVList = new List<AntiVirus>();
    private LevelData _currentLevel;

    public bool CanSpawn
    {
        get => _canSpawn;
    }

    public void Init(LevelData currentLevel)
    {
        _currentLevel = currentLevel;
        activeAVList.Clear();
        var list = _currentLevel.LevelPiece.GetComponentsInChildren<AntiVirus>();
        if(_currentLevel.LevelPiece !=null)
        {
            foreach (var av in list)
            {
                av.Init();
                activeAVList.Add(av);
            }
        }
        
    }
    public void SpawnDefenders(Transform desiredTR,MovementDirection movementDirection,float range,float velocity)
    {
        var antivirus = Object.Instantiate(_defender_Ref, desiredTR.position, desiredTR.rotation);
        antivirus.Init();
        antivirus.InitializeStats(movementDirection,range,velocity);
        _spawned_defenders_count += 1;
        _canSpawn = (_spawned_defenders_count >= _maxDefendersCount) ? false : true;

    }
    public void OnDestroy()
    {
        _spawned_defenders_count -= 1;
        _canSpawn = true;
    }
}
