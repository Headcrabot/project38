using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cellType    {   fields, hills, ocean, mountains }

public class cellScript : MonoBehaviour
{
    [SerializeField] private float fCellSize = 1f;
    public long lId { get; private set; } = 0;
    public cellType type { get; private set; } = cellType.fields;

    private SpriteRenderer render;

    private bool bInitialized = false;

    public void Initialize(long nId, cellType ntype, int row, int col, Vector2 offset)
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
        var sprite = Resources.Load<Sprite>($"Sprites/Map/{nameof(type)}");
        if (sprite)
            render.sprite = sprite;
        else
            Debug.LogError($"No {nameof(type)} sprite! Continuing without");
    }

    public float GetSize()
    {
        return fCellSize;
    }
}
