using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private AIManager _aiManager;
    private List<TrAvPair> _potentialSpawnPoints = new List<TrAvPair>();
    public GameObject _mouseBody;
    public GameObject _mouseSpawnerBody;
    private LevelData _currentLevel;
    private Transform _targetLocation;
    private float _targetApproachRate;
    private int _targetIndex;
    private enum MouseState
    {
        Idle,
        Aware,
        Boss
    };
    private MouseState _mouseState = MouseState.Idle;
    public void Init(AIManager aiManager, LevelData currentLevel)
    {
        _mouseBody.SetActive(false);
        _mouseSpawnerBody.SetActive(false);
        _aiManager = aiManager;
        this._currentLevel = currentLevel;
        if(_currentLevel.LevelPiece != null)
        {
            var tempArr = _currentLevel.LevelPiece.GetComponentsInChildren<TransformDirectionPair>();
            foreach (var item in tempArr)
            {
                var pair = new TrAvPair();
                pair.spawnPoint = item.transform;
                pair.direction = item.Direction;
                pair._range = item._range;
                pair._velocity = item._velocity;
            }
        }
        

    }

    public void Update()
    {   
        if(_mouseState == MouseState.Aware)
        {
            transform.position = Vector2.Lerp(transform.position, _targetLocation.position, _targetApproachRate);
        }
    }
    public void ActivateMouse(bool isBoss)
    {
        _mouseBody.SetActive(true);
        if (isBoss)
        {
            _mouseState = MouseState.Boss;
        }
        else
        {
            _mouseState = MouseState.Aware;
           _targetLocation =  PickLocation();
        }
    }
    public void DeActivateMouse()
    {
        _mouseState = MouseState.Idle;
        _mouseBody.SetActive(false);
    }

    public Transform PickLocation()
    {
        _targetIndex = Random.Range(0, _potentialSpawnPoints.Count);
        StartCoroutine(PuttingObjects());
        return _potentialSpawnPoints[_targetIndex].spawnPoint;
    }
    IEnumerator PuttingObjects()
    {

        yield return new WaitForSeconds(2);
        
        yield return new WaitForSeconds(0.5f);
        _aiManager.SpawnDefenders(_targetLocation, _potentialSpawnPoints[_targetIndex].direction, _potentialSpawnPoints[_targetIndex]._range, _potentialSpawnPoints[_targetIndex]._velocity);
        yield return new WaitForSeconds(0.25f);
        _mouseBody.SetActive(true);
        _mouseSpawnerBody.SetActive(false);
        if (_mouseState != MouseState.Idle) _targetLocation = PickLocation();
    }
}
public struct TrAvPair
{
    public Transform spawnPoint;
    public AntiVirus av;
    public MovementDirection direction;
    public float _range;
    public float _velocity;
}
