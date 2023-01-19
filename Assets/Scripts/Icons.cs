using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Icons : MonoBehaviour
{
   [SerializeField] private GameObject _openBox;
    private TextMeshPro _targetText;
   
    
    protected virtual void Awake()
    {
        _openBox.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Virus"))
        {
            _openBox.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Virus"))
        {
            _openBox.SetActive(false);
        }
    }
}
