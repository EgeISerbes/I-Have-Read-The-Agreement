using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDirectionPair : MonoBehaviour
{
    [SerializeField] private MovementDirection movementDirection = MovementDirection.Idle;
    public float _range;
    public float _velocity;
    public MovementDirection Direction
    {
        get => movementDirection;
    }
}
