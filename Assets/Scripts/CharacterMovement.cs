using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _inputs;
    private Vector2 _prevInputs;
    [SerializeField] private float _inputOffset;
    [SerializeField] private Vector2 _velocityMultiplier;
    private Vector3 _mousePosition;
    private Vector3 _charLookDirection;
    private Vector3 _velocity;
    private Transform _charTR;
    private float _rotAngle;
    [SerializeField] private float _cameraOffset;
    private AnimationManager _animManager;


    
    
    private enum CharacterState
    {
        Idle,
        Moving
    };
    private CharacterState _state = CharacterState.Idle;
    

    public void Init()
    {
        _charTR = gameObject.transform;
    }
    private void Awake()
    {
        _animManager = gameObject.GetComponent<AnimationManager>();

    }
    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

   public void PauseState()
    {
        _state = CharacterState.Idle;
        _animManager.SetState("canMoveHorizontal", false);

    }
    public void ResumeState()
    {
        _state = CharacterState.Moving;
        _animManager.SetState("canMoveHorizontal", true);
        
    }
    void ProcessMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _horizontalInput = (Mathf.Abs(_horizontalInput) < _inputOffset) ? 0 : _horizontalInput;
        
        _verticalInput = Input.GetAxis("Vertical");
        _verticalInput = (Mathf.Abs(_verticalInput) < _inputOffset) ? 0 : _verticalInput;
        if(Mathf.Abs(_verticalInput) !=0 || Mathf.Abs(_horizontalInput) != 0)
        {
            ResumeState();
        }
        else
        {
            PauseState();
        }
        _velocity = (new Vector2(_horizontalInput * _velocityMultiplier.x, _verticalInput * _velocityMultiplier.y));
        _charTR.position = _charTR.position + _velocity * Time.deltaTime;
    }
    void ProcessRotation()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * _cameraOffset);
        Vector3 difference = _mousePosition - _charTR.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
    }
}

