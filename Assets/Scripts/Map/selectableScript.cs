using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISelectable
{
    public string title { get; set; }
    public string desc { get; set; }

    public bool bSelected { get; }

    public void OnSelect(selectorScript selector);
}
