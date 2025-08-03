using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Layout", menuName = "Controls Layout")]
public class controlsLayout : ScriptableObject
{
    [SerializeField] private KeyCode _keyUp = KeyCode.UpArrow;
    [SerializeField] private KeyCode _keyDown = KeyCode.DownArrow;
    [SerializeField] private KeyCode _keyRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode _keyLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _keySelect = KeyCode.Space;


    public KeyCode keyUp { get => _keyUp; }
    public KeyCode keyDown { get => _keyDown; }
    public KeyCode keyRight { get => _keyRight; }
    public KeyCode keyLeft { get => _keyLeft; }
    public KeyCode keySelect { get => _keySelect; }
}
