using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basePopupWindowScript : MonoBehaviour
{
    private int iWidth = 120;
    private int iHeight = 200;

    private string title = "dev popup title";
    private string desc = "some usefull information we may need as we select something on the map";

    private Transform target;

    private RectTransform _rect;
    [SerializeField] private Text textTitle;
    [SerializeField] private Text textDescription;

    private bool bInitialized = false;
    public void Initialize(string ntitle = "dev popup title", string ndesc = "some usefull information we may need as we select something on the map")
    {
        if (bInitialized)
            return;

        _rect = GetComponent<RectTransform>();
        title = ntitle;
        desc = ndesc;

        bInitialized = true;
    }
    void OnGUI()
    {
        if (!bInitialized)
            return;


        textTitle.text = title;
        textDescription.text = desc;
        _rect.position = Camera.main.WorldToScreenPoint(target.position);
    }
}
