using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resources Config", menuName = "Resources Pathf Config")]
public class resourceMasterScript : ScriptableObject
{
    [SerializeField] private string[] _mapSpritesNames = { "fields", "hills", "ocean", "mountains" };


    public string[] mapSpriteNames {    get => _mapSpritesNames;    }
}
