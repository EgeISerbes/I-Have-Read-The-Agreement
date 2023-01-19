using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    [SerializeField] private Mouse _mouse;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Virus _virus;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _buttonPos;
    [SerializeField] private float _approachRate;
    private bool _canMove = false;
    [SerializeField] private GameObject _introLevel;
    public void AwakeIntro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _mouse.gameObject.SetActive(true);
        _mouse.transform.position = _startPos.position;
        //_virus.transform.position = _startPos.position;
        //_virus.gameObject.SetActive(false);
        StartCoroutine(IntroScene());
    }

    private void Update()
    {
        if (_canMove)
        {
            _mouse.transform.position = Vector2.Lerp(_mouse.transform.position, _buttonPos.position, _approachRate);
        }
    }

    IEnumerator IntroScene()
    {
        _canMove = true;
        yield return new WaitForSeconds(3);
        _mouse._mouseBody.gameObject.SetActive(false);
        _mouse._mouseSpawnerBody.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _mouse._mouseSpawnerBody.gameObject.SetActive(false);
        _virus.gameObject.SetActive(true);
        _introLevel.SetActive(false);
        _gameManager.AwakeManager();
        gameObject.SetActive(false);
    }
}
