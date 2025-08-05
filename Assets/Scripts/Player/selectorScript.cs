using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMasterScript))]
public class selectorScript : MonoBehaviour
{
    [SerializeField] private controlsLayout controls;

    private gameMasterScript master;

    private float fSensetive = 6.0f;
    private float fAcceleration = 8f;

    private float fHorizontal = 0f;
    private float fVertical = 0f;


    private bool bInitialized = false;

    public void Initialize()
    {
        if (controls == null)
            Debug.LogError("CONTROL LAYOUT UNASSIGNED!");

        master = gameMasterScript.master;
        bInitialized = true;
    }

    void Update()
    {
        bool bSelect = false;
        Vector2 input = HandleInput(controls, out bSelect);
        Vector3 delta = (new Vector3(input.x, input.y)) * fSensetive * Time.deltaTime;
        //Debug.Log($"{delta}");
        transform.Translate(delta);

        if (bSelect)
        {
            Collider2D[] allTouches = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
            Debug.Log(allTouches);
        }
    }

    private Vector2 HandleInput(controlsLayout layout, out bool bSelect)
    {
        bSelect = Input.GetKeyDown(layout.keySelect);

        if (Input.GetKey(layout.keyUp))
        {
            fVertical += fAcceleration * Time.deltaTime;
            //Debug.Log("Up");
        }
        else if (Input.GetKey(layout.keyDown))
        {
            fVertical -= fAcceleration * Time.deltaTime;
            //Debug.Log("Down");
        }
        else
        {
            fVertical -= DivideSafe(fVertical, Mathf.Abs(fVertical)) * fAcceleration * 2 * Time.deltaTime;
            if (Mathf.Abs(fVertical) < 0.1f)
                fVertical = 0f;
        }

        if (Input.GetKey(layout.keyRight))
        {
            fHorizontal += fAcceleration * Time.deltaTime;
            //Debug.Log("Right");
        }
        else if (Input.GetKey(layout.keyLeft))
        {
            fHorizontal -= fAcceleration * Time.deltaTime;
            //Debug.Log("Left");
        }
        else
        {
            fHorizontal -= DivideSafe(fHorizontal, Mathf.Abs(fHorizontal)) * fAcceleration * 2 * Time.deltaTime;
            if (Mathf.Abs(fHorizontal) < 0.1f)
                fHorizontal = 0f;
        }
        //Debug.Log($"{fHorizontal} : {fVertical}");
        fHorizontal = Mathf.Clamp(fHorizontal, -1f, 1f);
        fVertical = Mathf.Clamp(fVertical, -1f, 1f);
        Vector2 delta = new Vector2(fHorizontal, fVertical);
        //Debug.Log($"{delta}");
        return delta;
    }

    float DivideSafe(float a, float b)
    {
        if (b == 0)
            return 0f;
        return a / b;
    }
}
