using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(guiMasterScript))]
[RequireComponent(typeof(mapMasterScript))]
public class gameMasterScript : MonoBehaviour
{
    public static gameMasterScript master;
    private guiMasterScript gui;
    private mapMasterScript map;

    public float fCurrentSeasonTime { get; private set; } = 0.0f;
    public float fSeasonDuration { get; private set; } = 60.0f;

    public long lCurrentSeason { get; private set; } = 0;
    public long lSeasonsLimit { get; private set; } = 60;

    public bool bGamePaused { get; private set; } = false;

    [Header("Configuration")]
    public resourceMasterScript resources;

    [Header("Players")]
    public List<playerMasterScript> players = new List<playerMasterScript>();

    private void Awake()
    {
        master = this;
        gui = GetComponent<guiMasterScript>();
        map = GetComponent<mapMasterScript>();

        //players = FindObjectsByType<playerMasterScript>(FindObjectsSortMode.None);
    }

    private void Start()
    {
        gui.Initialize();
        map.InitializeMap();
        foreach (var player in players)
        {
            player.Initialize();
        }
    }

    private void Update()
    {
        if (bGamePaused)
            return;

        UpdateSeasons();
    }

    private void UpdateSeasons()
    {
        fCurrentSeasonTime += Time.deltaTime;
        if (fCurrentSeasonTime > fSeasonDuration)
        {
            fCurrentSeasonTime = 0f;
            lCurrentSeason++;
        }
    }
    public void SetPause(bool bNPause)
    {
        bGamePaused = bNPause;
    }
    public Sprite GetMapSpriteById(short id)
    {
        return Resources.Load<Sprite>($"Sprites/Map/{resources.mapSpriteNames[id]}");
    }
    public baseResourceScript GetResource(string rname)
    {
        if (Resources.Load<baseResourceScript>($"Resources/{rname}"))
            return Resources.Load<baseResourceScript>($"Resources/{rname}");
        Debug.Log($"ERROR: CANNOT FIND RESOURCE {rname}");
        return null;
    }
}
