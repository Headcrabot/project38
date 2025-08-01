using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMap", menuName = "Map Template")]
public class mapTemplateScript : ScriptableObject
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private string[] _map;

    public int width
    {
        get { return _width; }
    }
    public int height
    {
        get { return _height; }
    }
    public string[] map
    {
        get{ return _map; }
    }
}
