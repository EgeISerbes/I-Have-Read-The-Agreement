using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private float _ultDuration;
    [SerializeField] private float _skillDuration;
    [SerializeField] private GameObject _popupRef;
    [SerializeField] private GameObject _errorPopupScreen;
    private float _ultTimer, _skillTimer;
    private float _ultCooldown;
    private float _skillCooldown;
    private float _ult_cooldown_timer;
    private float _skill_cooldown_timer;
    private GameManager _manager;
    private enum SkillState
    {
        Idle,
        Skill,
        Ult
    };

    private SkillState _skillState = SkillState.Idle; 
    public void Init(GameObject ErrorScreen,GameManager manager)
    {
        _errorPopupScreen = ErrorScreen;
        _manager = manager;
    }

    public void UseUlt()
    {
        var obj = Instantiate(_errorPopupScreen, transform.position, transform.rotation);
    }
    public void UseSkill()
    {

    }

    public void SkillUsed(bool isUlt)
    {
        if (_skillState != SkillState.Idle) return;
        if(isUlt)
        {
            if (_ult_cooldown_timer < _ultCooldown) return;
            _skillState = SkillState.Ult;
            UseUlt();
            
        }
        else
        {
            if (_skill_cooldown_timer < _skillCooldown) return;
            _skillState = SkillState.Skill;
            UseSkill();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _ult_cooldown_timer += Time.deltaTime;
        _skill_cooldown_timer += Time.deltaTime;
        if(_skillState == SkillState.Ult)
        {
            _ultTimer += Time.deltaTime;
            if(_ultTimer>= _ultDuration)
            {
                _ultTimer = 0f;
                _ult_cooldown_timer = 0f;
                _skillState = SkillState.Idle;
            }
        }
        else if(_skillState == SkillState.Skill)
        {
            _skillTimer += Time.deltaTime;
            if(_skillTimer>=_skillDuration)
            {
                _skill_cooldown_timer = 0f;
                _skillTimer = 0f;
                _skillState = SkillState.Skill;
            }
        }


    }
}
