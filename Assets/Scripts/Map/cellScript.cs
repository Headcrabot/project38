using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellScript : MonoBehaviour
{
    [SerializeField] private float fCellSize = 1f;
    public long lId { get; private set; } = 0;
    public short type { get; private set; } = 0;

    private SpriteRenderer render;

    private bool bInitialized = false;

    [SerializeField] private List<baseResourceScript> resources;

    public void Initialize(long nId, short ntype, int row, int col, Vector2 offset)
    {
        if (bInitialized)
            return;


        bInitialized = true;
        lId = nId;
        transform.position = new Vector2(row * fCellSize, col * fCellSize) + offset;
        type = ntype;
        if (!GetComponent<SpriteRenderer>())
            gameObject.AddComponent<SpriteRenderer>();
        render = GetComponent<SpriteRenderer>();
        SpriteInitialize();
    }

    private void SpriteInitialize()
    {
        var sprite = gameMasterScript.master.GetMapSpriteById(type);
        if (sprite)
            render.sprite = sprite;
        else
            Debug.LogError($"{type} map sprite doesn't found! Continuing without it.");
    }

    public float GetSize()
    {
        return fCellSize;
    }
}
