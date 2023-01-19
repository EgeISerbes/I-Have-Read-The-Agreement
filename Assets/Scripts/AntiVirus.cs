using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirus : MonoBehaviour
{
    private AIMovement _aiMovement;
    private void Awake()
    {
        _aiMovement = GetComponent<AIMovement>();
    }
    public void Init()
    {
        _aiMovement.Init();
    }
    // Update is called once per frame
    public void GetHurt()
    {
        Destroy(gameObject);
    }
    public void InitializeStats(MovementDirection direction,float range,float velocity)
    {
        _aiMovement.SetDirection(direction);
        _aiMovement._range = range;
        _aiMovement._velocity =velocity;
    }
    
}
