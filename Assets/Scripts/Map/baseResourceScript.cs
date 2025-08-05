using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseResourceScript : ScriptableObject
{
    [SerializeField] private string _sName = "rice";
    [SerializeField] private short _iId = 0;

    public string sName
    {
        get
        {
            return _sName;
        }
    }
    public int iId
    {
        get
        {
            return _iId;
        }
    }
}
