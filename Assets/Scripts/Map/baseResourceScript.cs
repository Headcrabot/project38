using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new resource", menuName = "Resource")]
public class baseResourceScript : ScriptableObject
{
    [SerializeField] private string _sName = "rice";
    [SerializeField] private short _iId = 0;

    [SerializeField] private Sprite _sprite;

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
    public Sprite sprite
    {
        get
        {
            return _sprite;
        }
    }
}
