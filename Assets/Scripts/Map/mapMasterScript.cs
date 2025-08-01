using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMasterScript : MonoBehaviour
{
    [SerializeField] private GameObject prefabCell;
    [SerializeField] private mapTemplateScript map;
    [SerializeField] private GameObject mapParent;

    private bool bInitialized = false;

    public bool InitializeMap()
    {
        if (!map)
            return false;
        if (bInitialized)
            return false;

        if (!mapParent)
            mapParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.Euler(Vector3.zero));

        for (int row = 0; row < map.height; row++)
            {
                for (int col = 0; col < map.width; col++)
                {
                    //Debug.Log($"{map.map[row][col]} -> {(short)(map.map[row][col]-'0')}");
                    var obj = Instantiate(prefabCell, mapParent.transform);
                    obj.name = $"cell {row} {col}";
                    cellScript cell = obj.GetComponent<cellScript>();
                    cell.Initialize(row + col, (short)(map.map[row][col]-'0'), row, col, cell.GetSize() * new Vector2(-map.width / 2, -map.height / 2));
                }
            }

        bInitialized = true;
        return true;
    }
}
