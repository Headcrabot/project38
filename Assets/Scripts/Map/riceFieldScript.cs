using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UIElements;

[RequireComponent(typeof(cellScript))]
public class riceFieldScript : MonoBehaviour, ISelectable
{
    private cellScript _owner;
    private gameMasterScript _master;

    [SerializeField] private baseResourceScript rice;
    [SerializeField] private int iProductivity = 100;

    public string title { set; get; } = "";
    public string desc { set; get; } = "";
    public bool bSelected { set; get; } = false;

    private bool bInitialized = false;
    public void Initialize(baseResourceScript nres, int nproductivity = 100)
    {
        if (bInitialized)
            return;

        _master = gameMasterScript.master;
        _owner = GetComponent<cellScript>();

        rice = nres;
        _owner.AddVisualModifier(nres.sprite);
        iProductivity = nproductivity;
    }

    public int productivity
    {
        get { return iProductivity; }
    }

    public void OnSelect(selectorScript selector)
    {
        bSelected = true;
        Debug.Log(selector.gameObject.name);
    }
}
