using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderIcon : Icons
{
    [SerializeField] private GameObject _activeFolder;
    [SerializeField] private GameObject _inactiveFolder;

    protected override void Awake()
    {
        base.Awake();
        _activeFolder.SetActive(false);
        _inactiveFolder.SetActive(true);
    }

    public void ActivateFolder()
    {
        _activeFolder.SetActive(true);
        _inactiveFolder.SetActive(false);
    }

}
