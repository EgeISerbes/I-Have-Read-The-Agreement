using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _equipPressed = false;
    [SerializeField] private KeyCode _equip = KeyCode.E;
    private bool _attackPressed = false;
    private bool _skillPressed = false;
    private bool _ultPressed = false;
    [HideInInspector] public bool pausePressed = false;
    
    public bool CanEquip
    {
        get => _equipPressed;
    }
    public bool CanAttack
    {
        get => _attackPressed;
    }
    public bool SkillPressed
    {
        get => _skillPressed;
    }
    public bool UltPressed
    {
        get => _ultPressed;
    }
    void Update()
    {
        CheckForInputs();
    }

    // Update is called once per frame

    void CheckForInputs()
    {
        if (Input.GetKeyDown(_equip))
        {
            _equipPressed = true;

        }
        else if (Input.GetKeyUp(_equip))
        {
            _equipPressed = false;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            _attackPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _attackPressed = false;

        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
        {
            _ultPressed = true;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _ultPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Q))
        {
            _skillPressed = true;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _skillPressed = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePressed = true;
        }

    }
}
