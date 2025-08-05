using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(selectorScript))]
public class playerMasterScript : MonoBehaviour
{
    [SerializeField] private selectorScript selector;

    private gameMasterScript master;

    private bool bInitialized = false;

    public void Initialize()
    {
        if (bInitialized)
            return;
        master = gameMasterScript.master;
        if (!selector)
            selector = GetComponent<selectorScript>();
        selector.Initialize();
        bInitialized = true;
    }

    void Update()
    {
        if (!bInitialized)
            return;

        
    }   
}
