using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        selector.Initialize();
        bInitialized = true;
    }

    void Update()
    {
        if (!bInitialized)
            return;

        
    }
}
