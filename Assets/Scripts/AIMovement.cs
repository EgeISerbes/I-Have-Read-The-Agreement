using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    Horizontal,
    Vertical,
    Idle,
};
public class AIMovement : MonoBehaviour
{
    
    [SerializeField] private MovementDirection _direction = MovementDirection.Horizontal;
    public float _range = 0f;
    public float _velocity = 0f;
    private Vector2 _startPos;
    private float _diff;
    public void Init()
    {
        _startPos = transform.position;
    }
    
    public void SetDirection(MovementDirection direction)
    {
        _direction = direction;
    }
    void Update()
    {
        if (_direction == MovementDirection.Horizontal)
        {
            transform.position += new Vector3(_velocity * Time.deltaTime, 0,0);

            _diff = Mathf.Abs(transform.position.x - _startPos.x);
            if(_diff>_range)
            {
                _diff = 0;
                _velocity *= -1;
            }
        }
        else if(_direction == MovementDirection.Vertical)
        {
            transform.position += new Vector3(0,_velocity * Time.deltaTime, 0);

            _diff = Mathf.Abs(transform.position.y - _startPos.y);
            if (_diff > _range)
            {
                _diff = 0;
                _velocity *= -1;
            }
        }
    }
}
