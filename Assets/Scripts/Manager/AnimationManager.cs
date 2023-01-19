using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
   [SerializeField] private Animator _animator;


   public void SetState(string name, bool value)
    {
        _animator.SetBool(name, value);
    }
}
