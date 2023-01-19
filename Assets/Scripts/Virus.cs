using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private GameManager _gameManager;
   [SerializeField] private SkillManager _skillManager;
   [SerializeField] private Weapon _weapon;
   [SerializeField] private InputManager _inputs;
    private System.Action<bool> _onLevelChange;
    private CharacterMovement _c_Movement;
    private bool _is_in_trigger_area = false;
    private GameObject _errorScreenRef;
    private bool _isLoading = false;
   public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
        _skillManager.Init(_errorScreenRef, gameManager);
        _c_Movement = gameObject.GetComponent<CharacterMovement>();
        _c_Movement.Init();
        _c_Movement.PauseState();
        _weapon.Init();
    }


    private void Update()
    {
        if(_inputs.CanAttack)
        {
            _weapon.Fire();
        }
        if(_inputs.pausePressed)
        {
            _gameManager.GamePaused();
        }
    }

    IEnumerator WaitForBoolChange()
    {
        yield return new WaitForSeconds(1);
        _isLoading = false;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Foreground"))
    //    {

    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("ErrorScreen"))
    //    {

    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Icon"))
        {
            _is_in_trigger_area = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Icon"))
        {
            if(_inputs.CanEquip)
            {
                if (!_isLoading)
                {
                    _isLoading = true;
                    _gameManager.OnLevelChange(true);
                    _is_in_trigger_area = false;
                    StartCoroutine(WaitForBoolChange());
                }
            }
        }
    }
} 


